public interface IConfigurationService
{
    public IGameConfiguration GameConfiguration { get; }
    public ILanguageConfiguration Language { get; }
    public IGraphicsConfiguration Graphics { get; }
    public ISoundConfiguration Sound { get; }
}
