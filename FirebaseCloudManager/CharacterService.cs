using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseCloudManager
{
    class CharacterService
    {
        private const string FirebaseDatabaseUrl = "https://provafirebase-e63fd-default-rtdb.europe-west1.firebasedatabase.app/";
        private readonly FirebaseClient firebaseUser;
        public CharacterService()
        {
            firebaseUser = GetFirebaseUser(FirebaseDatabaseUrl, "2Ex9nEJ9vIcm4j8gB9SNN5e0Hb33");
        }
        public async Task AddCharacter(Character character)
        {
            await firebaseUser
            .Child("Characters")
            .PostAsync(character);
        }
        public async Task<List<Character>> GetCharacters()
        {
            var characters = await firebaseUser.Child("Characters").OnceAsync<Character>();
            foreach (var character in characters)
            {
                character.Object.Nom = character.Key;
            }
            return characters.Select(firebaseObject => firebaseObject.Object).ToList();
        }
        public List<Character> GetAllCharacters()
        {
            return GetCharacters().Result;
        }
        public static FirebaseClient GetFirebaseUser(string url, string secret = null)
        {
            return new FirebaseClient(url, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(secret)
            });
        }
    }
}
