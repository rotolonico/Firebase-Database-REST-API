using UnityEngine;

public class Main : MonoBehaviour
{
    /// <summary>
    /// This class is just the implementation of all the functions shown in DatabaseHandler
    /// - It will add two users to the database
    /// - It will retrieve the user with the id 11 from the database and print their age
    /// - It will retrieve all users from the database and print their names and surnames
    /// </summary>
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void OnAppStart()
    {
        var user1 = new User("Matt", "Smith", 36);
        DatabaseHandler.PostUser(user1, "11", () =>
        {
            DatabaseHandler.GetUser("11", user =>
            {
                Debug.Log($"{user.name}'s age is {user.age}");
            });
            
            DatabaseHandler.GetUsers(users =>
            {
                foreach (var user in users)
                {
                    Debug.Log($"{user.Value.name} {user.Value.surname} {user.Value.age}");
                }
            });
        });
        
        var user2 = new User("Peter", "Capaldi", 61);
        DatabaseHandler.PostUser(user2, "12",  () => { });
    }

}
