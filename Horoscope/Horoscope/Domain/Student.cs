namespace Horoscope.Domain
{
    public class Student : Entity
    {
        public string Name { get; set; }

        public bool HasAGoodDay()
        {
            int vowels = 0;

            foreach(var character in Name)
            {
                var c = char.ToLower(character);
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    vowels++;
                }
            }

            var day = DateTime.Now.Day;

            if (day % vowels == 0)
            {
                return true;
            }

            return false;
        }
    }
}
