using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SecureDocumentService
    {
        public static string Encrypt(string plainText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key.PadRight(32, '\0'));
                aesAlg.GenerateIV();

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);

                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key.PadRight(32, '\0')); 

                
                byte[] bytes = Convert.FromBase64String(cipherText);
                byte[] iv = bytes.Take(16).ToArray(); 
                byte[] cipherBytes = bytes.Skip(16).ToArray(); 

                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static string HashKey(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }

        public static bool VerifyKey(string enteredPassword, string storedHash)
        {
            return HashKey(enteredPassword) == storedHash;
        }

        public static EncryptionTableDTO SecureMessage(EncryptionTableDTO message)
        {
            var encryptedMessage = Encrypt(message.EncryptedText, message.Encryptionkey);
            message.EncryptedText = encryptedMessage;
            var hashedKey = HashKey(message.Encryptionkey);
            message.Encryptionkey = hashedKey;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<EncryptionTable, EncryptionTableDTO>();
                c.CreateMap<EncryptionTableDTO, EncryptionTable>();
            });
            var mapper = new Mapper(cfg);

            var mappedMessage = mapper.Map<EncryptionTable>(message);
            var data = DataAccessFactory.EncryptionTableData().Create(mappedMessage);
            return mapper.Map<EncryptionTableDTO>(data);
        }

        public static EncryptionTableDTO GetMessage(DecryptionDTO decryptionDTO)
        {
            var message = DataAccessFactory.EncryptionTableData().Read(decryptionDTO.Id);
            if(!VerifyKey(decryptionDTO.Encryptionkey, message.Encryptionkey))
            {
                return null;
            }
            var decryptedMessage = Decrypt(message.EncryptedText, decryptionDTO.Encryptionkey);
            message.EncryptedText = decryptedMessage;
            
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<EncryptionTable, EncryptionTableDTO>();
                c.CreateMap<EncryptionTableDTO, EncryptionTable>();
            });
            var mapper = new Mapper(cfg);

            return mapper.Map<EncryptionTableDTO>(message);

        }




    }
}
