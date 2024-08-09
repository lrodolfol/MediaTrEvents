namespace MediaTr.Manager.Requests;

public struct RecurrentPayload
{
    public String JobName { get; set; }
    public double TimeToProcess { get; set; }
}
