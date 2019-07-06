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


        public Dictionary<ulong, User> LoadMentees()
        {
            if (!File.Exists(Constants.MENTEE_FILE_PATH)) return new Dictionary<ulong, User>();
            _readStream = new FileStream(Constants.MENTEE_FILE_PATH, FileMode.Open, FileAccess.Read);
            return DeserializeFile(_readStream) ?? new Dictionary<ulong, User>();
        }

        public Dictionary<ulong, User> LoadMentors()
        {
            if (!File.Exists(Constants.MENTOR_FILE_PATH)) return new Dictionary<ulong, User>();
            _readStream = new FileStream(Constants.MENTOR_FILE_PATH, FileMode.Open, FileAccess.Read);

            return DeserializeFile(_readStream) == null ? DeserializeFile(_readStream) : new Dictionary<ulong, User>();
        }

        private static Dictionary<ulong, User> DeserializeFile(Stream fs)
        {
            BinaryFormatter bf = new BinaryFormatter();
            Dictionary<ulong, User> list = new Dictionary<ulong, User>();
            while (fs.Position != fs.Length)
            {
                var deserialized = (User)bf.Deserialize(fs);
                list.Add(deserialized.Id, deserialized);
            }
            return list;
        }

        public void SaveMentees(Dictionary<ulong, User> users)
        {
            _writeStream = new FileStream(Constants.MENTEE_FILE_PATH, FileMode.Append, FileAccess.Write);
            foreach (var user in users.Values)
            {
                Save(user);
            }
        }

        public void SaveMentors(Dictionary<ulong, User> users)
        {
            _writeStream = new FileStream(Constants.MENTOR_FILE_PATH, FileMode.Append, FileAccess.Write);

            foreach (var user in users.Values)
            {
                SaveMentor(user);
            }
        }

        public void SaveMentee(User user)
        {
            _writeStream = new FileStream(Constants.MENTEE_FILE_PATH, FileMode.Append, FileAccess.Write);
            Save(user);
        }

        public void SaveMentor(User user)
        {
            _writeStream = new FileStream(Constants.MENTOR_FILE_PATH, FileMode.Append, FileAccess.Write);
            Save(user);
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
