using System.Reflection;

namespace Stytch.Net.IntegrationTests.Resources.Data.Factories;

public class TestUserFactory
{
    private List<TestUser> _createdUsers = new();

    public void ClearUsers()
    {
        _createdUsers = new List<TestUser>();
    }

    public TestUser CreateMockUser()
    {
        bool uniqueUser;
        TestUser newUser;

        do
        {
            newUser = new TestUser();
            uniqueUser = UserIsUnique(newUser);
        } while (!uniqueUser);

        _createdUsers.Add(newUser);
        return newUser;
    }

    public List<TestUser> CreateMockUsers(int count)
    {
        List<TestUser> users = new();
        for (int i = 0; i < count; i++)
            users.Add(CreateMockUser());
        _createdUsers.AddRange(users);
        return users;
    }

    private bool UserIsUnique(TestUser user)
    {
        foreach (TestUser existingUser in _createdUsers)
            if (ObjectsHaveDuplicateValues(user, existingUser))
                return false;

        return true;
    }

    private bool ObjectsHaveDuplicateValues(object instance1, object instance2)
    {
        PropertyInfo[] properties = instance1.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in properties)
            if (prop.GetValue(instance1) == prop.GetValue(instance2))
                return true;

        return false;
    }
}