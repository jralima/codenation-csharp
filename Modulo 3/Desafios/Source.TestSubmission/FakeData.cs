namespace Codenation.Challenge
{
    public class FakeData
    {
        [Add]
        private decimal addValue;

        [Subtract]
        private decimal subtractValue;

        private decimal attributelessValue;

        public void SetAdd(decimal value)
        {
            this.addValue = value;
        }

        public void SetSubtract(decimal value)
        {
            this.subtractValue = value;
        }

        public void SetAttributeless(decimal value)
        {
            this.attributelessValue = value;
        }

    }
}