namespace DDReport
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Facebook fb = new Facebook(
                "sb=GGdOZAC4CBswfntrnUHU0Pf9;m_ls=%7B%22c%22%3A%7B%221%22%3A%22HCwAABbA0goWlMWH7w4TBRawjdmqm74tAA%22%2C%222%22%3A%22GSwVQBxMAAAWABaW39jJDBYAABV-HEwAABYAFqbf2MkMFgAAFigA%22%2C%2295%22%3A%22HCwRAAAW-AEWkKDT3QkTBRawjdmqm74tAA%22%7D%2C%22d%22%3A%22aa9056df-687c-4314-854d-0bf73d25253f%22%2C%22s%22%3A%220%22%2C%22u%22%3A%22jjwpo7%22%7D;ps_n=1;ps_l=1;c_user=100001772488790;datr=_pxFZkWGYTtiGMiLrPbA0HmB;usida=eyJ2ZXIiOjEsImlkIjoiQXNlMHNwZjFmZmsxMWMiLCJ0aW1lIjoxNzE2NjA0NzU1fQ%3D%3D;xs=24%3AYu_0TklnXaaQPw%3A2%3A1715838204%3A-1%3A2295%3A%3AAcXitPrfs6LyDIkRkvBtd1DKXnd_bkIhTjWV-aYwBtk;wd=1537x813;fr=1NYN2jYldn094Ul5G.AWWhRqQT9bdyLN9low_l0B8a5N0.BmUWEx..AAA.0.0.BmUWbi.AWVRskEk7vo;presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1716610808226%2C%22v%22%3A1%7D;",
                "https://www.facebook.com/heymywife/posts/pfbid0Ks6tkYLQ2e4uAxSiBrYj18MWyco1DzEkLqFBZvxj9dE3NBnunCc4BGnBMhCAHU7Ll"
            );
            await fb.start_session();
        }
    }
}
