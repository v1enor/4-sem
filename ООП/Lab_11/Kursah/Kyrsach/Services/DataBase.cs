using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NBitcoin;

namespace Kyrsach
{
    internal class DataBase
    {
        private HashFunc Hash = new HashFunc();

        public string HashFuncExamination(string source)
        {
            using (var sha256Hash = SHA256.Create())
            {
                var hash = Hash.GetHash(sha256Hash, source);
                return hash;
            }
        }



        public List<User> CheckLoginAndPassword(string login, string password)
        {
            using (var db = new CursachContext())
            {
                var user = db.User.Where(u => u.Password == password)
                    .Where(u => u.UserName == login.ToString())
                    .ToList();

                return user;
            }
        }

        public bool RegisterInDataBase(string login, string PasswordHash, string mail, string seed)
        {
            try
            {
                using (var db = new CursachContext())
                {
                    var users_id = db.User.OrderByDescending(p => p.IdUser).FirstOrDefault();

                    int idforuser = 0;
                    if (users_id != null)
                    {
                        idforuser = Convert.ToInt32(users_id.IdUser) + 1;
                    }

                    var user = new User
                    {
                        Mail = mail, 
                        Password = PasswordHash, 
                        UserName = login, 
                        Admin = false, 
                        Mnemomic = seed,
                        IdUser = idforuser
                    };

                    db.Add(user);
                    db.SaveChanges();
                }

                using (var db = new CursachContext())
                {
                    var mnemo = new Mnemonic(seed, Wordlist.English);
                    var masterKey = mnemo.DeriveExtKey("");
                    var adressets = masterKey.ToString(Network.Main);

                    var rnd = new Random();
                    var count_of_curencys = db.CurrencyList.Count();

                    var user_id = db.User.Where(u => u.Password == PasswordHash)
                        .Where(u => u.UserName == login.ToString());


                    var vr = new List<Tokens>();

                    for (var i = 1; i <= count_of_curencys; i++)
                    {
                        Guid txhash = Guid.NewGuid();
                        var key = masterKey.Derive((uint)i);
                        var tk = new Tokens(i, txhash.ToString(), key.ToString(Network.Main), rnd.Next(1, 20), user_id.First().IdUser);
                        vr.Add(tk);
                    }

                    db.AddRange(vr);
                    db.SaveChanges();
                    return true;
                }
            }


            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        
    }
}