// See https://aka.ms/new-console-template for more information
internal class Employee : IComparable<Employee>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public int Age { get; set; }

    public int CompareTo(Employee other)
    {
        if (other == null)
        {
            return 1;
        }

        return Age.CompareTo(other.Age);
    }
}