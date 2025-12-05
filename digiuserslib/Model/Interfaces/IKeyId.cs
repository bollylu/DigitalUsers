namespace digiuserslib.Model;

public interface IKeyId : IId<string>, ILoggable, IInvalid, IEqualityComparer<IKeyId> {

  public static IKeyId Empty => new TKeyId(string.Empty);

}
