namespace QuickShop
{
    class Movie : Media
    {
        public Movie(string s1, string s2, short sh, int i1, string s3, int i2)
        {
            Name = s1;
            Artist = s2;
            Rating = sh;
            Runtime = i1;
            Releasedate = s3;
            Price = i2;
        }
    }
}
