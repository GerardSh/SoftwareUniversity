namespace DefiningClasses
{
    internal class DateModifier
    {
        public int DateDifference { get; set; }

        public void GetDateDifference(string[] datesData)
        {
              DateTime dateOne = DateTime.Parse(datesData[0]);
              DateTime dateTwo = DateTime.Parse(datesData[1]);

            var difference = (dateOne - dateTwo).Days;

            DateDifference = Math.Abs(difference);
        }
    }
}
