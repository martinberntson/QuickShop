namespace QuickShop
{
    class Album : Media
    {
        public string[] tracknames { get; set; }
        public int[] trackruntimes { get; set; }
        public string[] trackfeatartists { get; set; }
        public Album(string s1, string s2, short sh, int i1, string s3, int i2, string[] sa1, int[] ia, string[]sa2)
        {
            Name = s1;
            Artist = s2;
            Rating = sh;
            Runtime = i1;
            Releasedate = s3;
            Price = i2;
            tracknames = new string[sa1.Length];
            trackruntimes = new int[ia.Length];
            trackfeatartists = new string[sa2.Length];


            for (int i = 0; i < sa1.Length; i++)
            {
                tracknames[i] = sa1[i];
            }
            for (int i = 0; i < ia.Length; i++)
            {
                trackruntimes[i] = ia[i];
            }
            for (int i = 0; i < sa2.Length; i++)
            {
                trackfeatartists[i] = sa2[i];
            }
        }
    }
}
