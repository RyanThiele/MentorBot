using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.Registry;

namespace DiscordBot.Storage
{
    public class UserDb : IDisposable
    {
        private Stream _writeStream;
        private Stream _readStream;


        public HashSet<Mentee> LoadMentees()
        {
            _readStream = new FileStream(Constants.MENTEE_FILE_PATH, FileMode.Open, FileAccess.Read);
            return DeserializeFile<Mentee>(_readStream);
        }

        public HashSet<Mentor> LoadMentors()
        {
            _readStream = new FileStream(Constants.MENTOR_FILE_PATH, FileMode.Open, FileAccess.Read);
            return DeserializeFile<Mentor>(_readStream);
        }

        private static HashSet<T> DeserializeFile<T>(Stream fs)
        {
            BinaryFormatter bf = new BinaryFormatter();
            HashSet<T> list = new HashSet<T>();
            while (fs.Position != fs.Length)
            {
                var deserialized = (T)bf.Deserialize(fs);
                list.Add(deserialized);
            }
            return list;
        }

        public void Save(HashSet<Mentee> users)
        {
            _writeStream = new FileStream(Constants.MENTEE_FILE_PATH, FileMode.Append, FileAccess.Write);
            foreach (var user in users)
            {
                Save(user);
            }
        }

        public void Save(HashSet<Mentor> users)
        {
            _writeStream = new FileStream(Constants.MENTOR_FILE_PATH, FileMode.Append, FileAccess.Write);

            foreach (var user in users)
            {
                Save(user);
            }
        }

        private void Save(User user)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(_writeStream, user);
        }

        public void Dispose()
        {
            _writeStream?.Dispose();
            _readStream?.Dispose();
        }

    }
}
