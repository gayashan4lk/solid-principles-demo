namespace ArdalisRating
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromJsonString(string jsonString);
    }
}
