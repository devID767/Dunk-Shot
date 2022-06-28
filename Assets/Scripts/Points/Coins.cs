public class Coins : Point
{
    public bool DecreaseOn(int value)
    {
        if (_value - value >= 0)
        {
            _value -= value;

            InvokeAction();

            return true;
        }
        else
        {
            return false;
        }
    }
}
