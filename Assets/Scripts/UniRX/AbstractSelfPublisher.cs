using UniRx;

public class AbstractSelfPublisher
{
    public void PublishSelf()
    {
        MessageBroker.Default
            .Publish(this);
    }
}
