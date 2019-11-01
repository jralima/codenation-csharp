namespace Codenation.Challenge
{
    public class FakeAttributeLessData
    {
        private decimal addValue;

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