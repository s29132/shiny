namespace AppKontenery;

public interface IHazardNotifier
{
    void SendHazardMessage(string serialNumber);
}