// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AllOf2
    {
        [JsonProperty("$ref")]
        public string Ref { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public Items items { get; set; }
        public int minItems { get; set; }
        public List<string> @enum { get; set; }
    }

    public class AttributeName
    {
        public string localPart { get; set; }
        public string namespaceURI { get; set; }
    }

    public class StreamId
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class ChannelId
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Description
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Status
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class PublishDate
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Properties
    {
        public StreamId streamId { get; set; }
        public ChannelId channelId { get; set; }
        public Description description { get; set; }
        public Status status { get; set; }
        public PublishDate publishDate { get; set; }
        public SimilarArtist similarArtist { get; set; }
        public MusicFolders musicFolders { get; set; }
        public Indexes indexes { get; set; }
        public Directory directory { get; set; }
        public Genres genres { get; set; }
        public Artists artists { get; set; }
        public Artist artist { get; set; }
        public Album album { get; set; }
        public Song song { get; set; }
        public Videos videos { get; set; }
        public VideoInfo videoInfo { get; set; }
        public NowPlaying nowPlaying { get; set; }
        public SearchResult searchResult { get; set; }
        public SearchResult2 searchResult2 { get; set; }
        public SearchResult3 searchResult3 { get; set; }
        public Playlists playlists { get; set; }
        public Playlist playlist { get; set; }
        public JukeboxStatus jukeboxStatus { get; set; }
        public JukeboxPlaylist jukeboxPlaylist { get; set; }
        public License license { get; set; }
        public Users users { get; set; }
        public User user { get; set; }
        public ChatMessages chatMessages { get; set; }
        public AlbumList albumList { get; set; }
        public AlbumList2 albumList2 { get; set; }
        public RandomSongs randomSongs { get; set; }
        public SongsByGenre songsByGenre { get; set; }
        public Lyrics lyrics { get; set; }
        public Podcasts podcasts { get; set; }
        public NewestPodcasts newestPodcasts { get; set; }
        public InternetRadioStations internetRadioStations { get; set; }
        public Bookmarks bookmarks { get; set; }
        public PlayQueue playQueue { get; set; }
        public Shares shares { get; set; }
        public Starred starred { get; set; }
        public Starred2 starred2 { get; set; }
        public AlbumInfo albumInfo { get; set; }
        public ArtistInfo artistInfo { get; set; }
        public ArtistInfo2 artistInfo2 { get; set; }
        public SimilarSongs similarSongs { get; set; }
        public SimilarSongs2 similarSongs2 { get; set; }
        public TopSongs topSongs { get; set; }
        public ScanStatus scanStatus { get; set; }
        public Error error { get; set; }
        public Version version { get; set; }
        public Episode episode { get; set; }
        public Entry entry { get; set; }
        public Id id { get; set; }
        public Url url { get; set; }
        public Username username { get; set; }
        public Created created { get; set; }
        public Expires expires { get; set; }
        public LastVisited lastVisited { get; set; }
        public VisitCount visitCount { get; set; }
        public Name name { get; set; }
        public StreamUrl streamUrl { get; set; }
        public HomePageUrl homePageUrl { get; set; }
        public Shortcut shortcut { get; set; }
        public Index index { get; set; }
        public Child child { get; set; }
        public LastModified lastModified { get; set; }
        public IgnoredArticles ignoredArticles { get; set; }
        public Parent parent { get; set; }
        public UserRating userRating { get; set; }
        public AverageRating averageRating { get; set; }
        public PlayCount playCount { get; set; }
        public Scanning scanning { get; set; }
        public Count count { get; set; }
        public Code code { get; set; }
        public Message message { get; set; }
        public Genre genre { get; set; }
        public ArtistId artistId { get; set; }
        public CoverArt coverArt { get; set; }
        public SongCount songCount { get; set; }
        public Duration duration { get; set; }
        public Year year { get; set; }
        public Position position { get; set; }
        public Comment comment { get; set; }
        public Changed changed { get; set; }
        public AllowedUser allowedUser { get; set; }
        public Owner owner { get; set; }
        public Public _public { get; set; }
        public ChatMessage chatMessage { get; set; }
        public Valid valid { get; set; }
        public Email email { get; set; }
        public LicenseExpires licenseExpires { get; set; }
        public TrialExpires trialExpires { get; set; }
        public Content content { get; set; }
        public AlbumCount albumCount { get; set; }
        public ArtistImageUrl artistImageUrl { get; set; }
        public LanguageCode languageCode { get; set; }
        public Bookmark bookmark { get; set; }
        public Video video { get; set; }
        public Notes notes { get; set; }
        public MusicBrainzId musicBrainzId { get; set; }
        public LastFmUrl lastFmUrl { get; set; }
        public SmallImageUrl smallImageUrl { get; set; }
        public MediumImageUrl mediumImageUrl { get; set; }
        public LargeImageUrl largeImageUrl { get; set; }
        public MusicFolder musicFolder { get; set; }
        public Share share { get; set; }
        public MinutesAgo minutesAgo { get; set; }
        public PlayerId playerId { get; set; }
        public PlayerName playerName { get; set; }
        public CurrentIndex currentIndex { get; set; }
        public Playing playing { get; set; }
        public Gain gain { get; set; }
        public InternetRadioStation internetRadioStation { get; set; }
        public Title title { get; set; }
        public Captions captions { get; set; }
        public AudioTrack audioTrack { get; set; }
        public Conversion conversion { get; set; }
        public Folder folder { get; set; }
        public ScrobblingEnabled scrobblingEnabled { get; set; }
        public MaxBitRate maxBitRate { get; set; }
        public AdminRole adminRole { get; set; }
        public SettingsRole settingsRole { get; set; }
        public DownloadRole downloadRole { get; set; }
        public UploadRole uploadRole { get; set; }
        public PlaylistRole playlistRole { get; set; }
        public CoverArtRole coverArtRole { get; set; }
        public CommentRole commentRole { get; set; }
        public PodcastRole podcastRole { get; set; }
        public StreamRole streamRole { get; set; }
        public JukeboxRole jukeboxRole { get; set; }
        public ShareRole shareRole { get; set; }
        public VideoConversionRole videoConversionRole { get; set; }
        public AvatarLastChanged avatarLastChanged { get; set; }
        public Biography biography { get; set; }
        public Match match { get; set; }
        public Offset offset { get; set; }
        public TotalHits totalHits { get; set; }
        public IsDir isDir { get; set; }
        public Track track { get; set; }
        public Size size { get; set; }
        public ContentType contentType { get; set; }
        public Suffix suffix { get; set; }
        public TranscodedContentType transcodedContentType { get; set; }
        public TranscodedSuffix transcodedSuffix { get; set; }
        public BitRate bitRate { get; set; }
        public Path path { get; set; }
        public IsVideo isVideo { get; set; }
        public DiscNumber discNumber { get; set; }
        public AlbumId albumId { get; set; }
        public Type type { get; set; }
        public BookmarkPosition bookmarkPosition { get; set; }
        public OriginalWidth originalWidth { get; set; }
        public OriginalHeight originalHeight { get; set; }
        public Channel channel { get; set; }
        public Time time { get; set; }
        public Current current { get; set; }
        public ChangedBy changedBy { get; set; }
        public AudioTrackId audioTrackId { get; set; }
        public OriginalImageUrl originalImageUrl { get; set; }
        public ErrorMessage errorMessage { get; set; }
        public LocalPart localPart { get; set; }
        public NamespaceURI namespaceURI { get; set; }
        public Value value { get; set; }
    }

    public class TypeName
    {
        public string localPart { get; set; }
        public string namespaceURI { get; set; }
    }

    public class PodcastEpisode
    {
        public List<string> required { get; set; }
        public List<AllOf> allOf { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Items
    {
        [JsonProperty("$ref")]
        public string Ref { get; set; }
    }

    public class ElementName
    {
        public string localPart { get; set; }
        public string namespaceURI { get; set; }
    }

    public class SimilarArtist
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class ArtistInfo
    {
        public List<AllOf> allOf { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class MusicFolders
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Indexes
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Directory
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Genres
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Artists
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Artist
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Album
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Song
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Videos
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class VideoInfo
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class NowPlaying
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class SearchResult
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class SearchResult2
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class SearchResult3
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Playlists
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Playlist
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class JukeboxStatus
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class JukeboxPlaylist
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class License
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Users
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class User
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class ChatMessages
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class AlbumList
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class AlbumList2
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class RandomSongs
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class SongsByGenre
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Lyrics
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Podcasts
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class NewestPodcasts
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class InternetRadioStations
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Bookmarks
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class PlayQueue
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Shares
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Starred
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Starred2
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class AlbumInfo
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class ArtistInfo2
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class ArtistInfo22
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class SimilarSongs
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class SimilarSongs2
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class TopSongs
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class ScanStatus
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Error
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Version
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Response
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Episode
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class NewestPodcasts2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Entry
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Id
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Url
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Username
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Created
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Expires
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class LastVisited
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class VisitCount
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Share
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Name
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class StreamUrl
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class HomePageUrl
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class InternetRadioStation
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class PlaylistWithSongs
    {
        public List<AllOf> allOf { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class MusicFolder
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Shortcut
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Index
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Child
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class LastModified
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class IgnoredArticles
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Indexes2
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class AlbumWithSongsID3
    {
        public List<AllOf> allOf { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Parent
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class UserRating
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class AverageRating
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class PlayCount
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Directory2
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Scanning
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Count
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class ScanStatus2
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class ArtistsID3
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Code
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Message
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Error2
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class SimilarSongs3
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Genre
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Genres2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class ArtistId
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class CoverArt
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class SongCount
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Duration
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Year
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class AlbumID3
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Position
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Comment
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Changed
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Bookmark
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class SearchResult22
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Users2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Starred5
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class AllowedUser
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Owner
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Public
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Playlist2
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class ChatMessage
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class ChatMessages2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class TopSongs2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Captions
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class JukeboxPlaylist2
    {
        public List<AllOf> allOf { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Valid
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Email
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class LicenseExpires
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class TrialExpires
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class License2
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class SimilarSongs22
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Content
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
    }

    public class AlbumCount
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Genre3
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class ArtistInfo23
    {
        public List<AllOf> allOf { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Index3
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class ArtistImageUrl
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class ArtistID3
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class LanguageCode
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class AudioTrack
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class ArtistWithAlbumsID3
    {
        public List<AllOf> allOf { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Bookmark2
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Bookmarks2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Video
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Videos2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class SearchResult32
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Notes
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class MusicBrainzId
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class LastFmUrl
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class SmallImageUrl
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class MediumImageUrl
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class LargeImageUrl
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class AlbumInfo2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class MusicFolder2
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class MusicFolders2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Playlists2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Share2
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Shares2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class MinutesAgo
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class PlayerId
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class PlayerName
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class NowPlayingEntry
    {
        public List<string> required { get; set; }
        public List<AllOf> allOf { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class CurrentIndex
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Playing
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Gain
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class JukeboxStatus2
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class InternetRadioStation2
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class InternetRadioStations2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Title
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Lyrics2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Starred22
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Captions2
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class AudioTrack2
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Conversion
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class VideoInfo2
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Folder
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class ScrobblingEnabled
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class MaxBitRate
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class AdminRole
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class SettingsRole
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class DownloadRole
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class UploadRole
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class PlaylistRole
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class CoverArtRole
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class CommentRole
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class PodcastRole
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class StreamRole
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class JukeboxRole
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class ShareRole
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class VideoConversionRole
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class AvatarLastChanged
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class User3
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Songs
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Biography
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class ArtistInfoBase
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Match
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Offset
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class TotalHits
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class SearchResult4
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class AlbumList22
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class IsDir
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Track
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Size
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class ContentType
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Suffix
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class TranscodedContentType
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class TranscodedSuffix
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class BitRate
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Path
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class IsVideo
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class DiscNumber
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class AlbumId
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Type
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class BookmarkPosition
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class OriginalWidth
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class OriginalHeight
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class Child3
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Channel
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Podcasts2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class IndexID3
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Time
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class ChatMessage2
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Artist11
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class AlbumList3
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class NowPlaying2
    {
        public string type { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class Current
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class ChangedBy
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class PlayQueue2
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class AudioTrackId
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class VideoConversion
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class OriginalImageUrl
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class ErrorMessage
    {
        public string title { get; set; }
        public List<AllOf> allOf { get; set; }
        public string propertyType { get; set; }
        public AttributeName attributeName { get; set; }
    }

    public class PodcastChannel
    {
        public string type { get; set; }
        public string title { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
        public List<string> propertiesOrder { get; set; }
    }

    public class PodcastStatus
    {
        public List<AllOf> allOf { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
    }

    public class MediaType
    {
        public List<AllOf> allOf { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
    }

    public class ResponseStatus
    {
        public List<AllOf> allOf { get; set; }
        public string typeType { get; set; }
        public TypeName typeName { get; set; }
    }

    public class Definitions
    {
        public PodcastEpisode PodcastEpisode { get; set; }
        public ArtistInfo ArtistInfo { get; set; }
        public Response Response { get; set; }
        public NewestPodcasts NewestPodcasts { get; set; }
        public Share Share { get; set; }
        public InternetRadioStation InternetRadioStation { get; set; }
        public PlaylistWithSongs PlaylistWithSongs { get; set; }
        public MusicFolder MusicFolder { get; set; }
        public Indexes Indexes { get; set; }
        public AlbumWithSongsID3 AlbumWithSongsID3 { get; set; }
        public Directory Directory { get; set; }
        public ScanStatus ScanStatus { get; set; }
        public ArtistsID3 ArtistsID3 { get; set; }
        public Error Error { get; set; }
        public SimilarSongs SimilarSongs { get; set; }
        public Genres Genres { get; set; }
        public AlbumID3 AlbumID3 { get; set; }
        public Bookmark Bookmark { get; set; }
        public SearchResult2 SearchResult2 { get; set; }
        public Users Users { get; set; }
        public Starred Starred { get; set; }
        public Playlist Playlist { get; set; }
        public ChatMessages ChatMessages { get; set; }
        public TopSongs TopSongs { get; set; }
        public Captions Captions { get; set; }
        public JukeboxPlaylist JukeboxPlaylist { get; set; }
        public License License { get; set; }
        public SimilarSongs2 SimilarSongs2 { get; set; }
        public Genre Genre { get; set; }
        public ArtistInfo2 ArtistInfo2 { get; set; }
        public Index Index { get; set; }
        public ArtistID3 ArtistID3 { get; set; }
        public AudioTrack AudioTrack { get; set; }
        public ArtistWithAlbumsID3 ArtistWithAlbumsID3 { get; set; }
        public Bookmarks Bookmarks { get; set; }
        public Videos Videos { get; set; }
        public SearchResult3 SearchResult3 { get; set; }
        public AlbumInfo AlbumInfo { get; set; }
        public MusicFolders MusicFolders { get; set; }
        public Playlists Playlists { get; set; }
        public Shares Shares { get; set; }
        public NowPlayingEntry NowPlayingEntry { get; set; }
        public JukeboxStatus JukeboxStatus { get; set; }
        public InternetRadioStations InternetRadioStations { get; set; }
        public Lyrics Lyrics { get; set; }
        public Starred2 Starred2 { get; set; }
        public VideoInfo VideoInfo { get; set; }
        public User User { get; set; }
        public Songs Songs { get; set; }
        public ArtistInfoBase ArtistInfoBase { get; set; }
        public SearchResult SearchResult { get; set; }
        public AlbumList2 AlbumList2 { get; set; }
        public Child Child { get; set; }
        public Podcasts Podcasts { get; set; }
        public IndexID3 IndexID3 { get; set; }
        public ChatMessage ChatMessage { get; set; }
        public Artist Artist { get; set; }
        public AlbumList AlbumList { get; set; }
        public NowPlaying NowPlaying { get; set; }
        public PlayQueue PlayQueue { get; set; }
        public VideoConversion VideoConversion { get; set; }
        public PodcastChannel PodcastChannel { get; set; }
        public PodcastStatus PodcastStatus { get; set; }
        public MediaType MediaType { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }

    public class LocalPart
    {
        public List<string> @enum { get; set; }
    }

    public class NamespaceURI
    {
        public List<string> @enum { get; set; }
    }

    public class Value
    {
        [JsonProperty("$ref")]
        public string Ref { get; set; }
    }

    public class AnyOf
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public ElementName elementName { get; set; }
    }

    public class Root
    {
        public string id { get; set; }
        public Definitions definitions { get; set; }
        public List<AnyOf> anyOf { get; set; }
    }

