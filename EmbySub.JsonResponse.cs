using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmbySub
{
 

    public partial class JsonResponse
    {

        [JsonPropertyName("subsonic-response")]
        public Dictionary<string, object> root { get; set; } = new Dictionary<string, object>()
        {
            {"_xmlns", "http://subsonic.org/restapi"},
            {"_version", "1.16.1"}
        };

        public PodcastEpisode PodcastEpisode { get; set; }
        public ArtistInfo ArtistInfo { get; set; }
        public Child2 Response { get; set; }
        public NewestPodcasts NewestPodcasts { get; set; }
        public Share Share { get; set; }
        public InternetRadioStation InternetRadioStation { get; set; }
        public JukeboxPlaylist PlaylistWithSongs { get; set; }
        public Captions MusicFolder { get; set; }
        public Indexes Indexes { get; set; }
        public AlbumWithSongsId3 AlbumWithSongsId3 { get; set; }
        public Directory Directory { get; set; }
        public ScanStatus ScanStatus { get; set; }
        public ArtistsId3 ArtistsId3 { get; set; }

        [JsonPropertyName("error")]
        public Error Error { get; set; }
        public SimilarSongs SimilarSongs { get; set; }
        public Genres Genres { get; set; }
        public AlbumId3 AlbumId3 { get; set; }
        public Bookmark Bookmark { get; set; }
        public SearchResult2 SearchResult2 { get; set; }
        public Users Users { get; set; }
        public SearchResult2 Starred { get; set; }
        public Playlist Playlist { get; set; }
        public ChatMessages ChatMessages { get; set; }
        public SimilarSongs TopSongs { get; set; }
        public Captions Captions { get; set; }
        public JukeboxPlaylist JukeboxPlaylist { get; set; }
        public License License { get; set; }
        public SimilarSongs SimilarSongs2 { get; set; }
        public Genre Genre { get; set; }
        public ArtistInfo ArtistInfo2 { get; set; }
        public Index Index { get; set; }
        public ArtistId3 ArtistId3 { get; set; }
        public AudioTrack AudioTrack { get; set; }
        public ArtistWithAlbumsId3 ArtistWithAlbumsId3 { get; set; }
        public Bookmarks Bookmarks { get; set; }
        public Videos Videos { get; set; }
        public SearchResult2 SearchResult3 { get; set; }
        public AlbumInfo AlbumInfo { get; set; }
        public MusicFolders MusicFolders { get; set; }
        public Playlists Playlists { get; set; }
        public Shares Shares { get; set; }
        public NowPlayingEntry NowPlayingEntry { get; set; }
        public JukeboxStatus JukeboxStatus { get; set; }
        public InternetRadioStations InternetRadioStations { get; set; }
        public Lyrics Lyrics { get; set; }
        public SearchResult2 Starred2 { get; set; }
        public VideoInfo VideoInfo { get; set; }
        public User User { get; set; }
        public SimilarSongs Songs { get; set; }
        public AlbumInfo ArtistInfoBase { get; set; }
        public SearchResult SearchResult { get; set; }
        public AlbumList AlbumList2 { get; set; }
        public Child2 Child { get; set; }
        public Podcasts Podcasts { get; set; }
        public Index IndexId3 { get; set; }
        public ChatMessage ChatMessage { get; set; }
        public ArtistClass Artist { get; set; }
        
        [JsonPropertyName("albumList")]
        public AlbumList AlbumList { get; set; }
        public NowPlaying NowPlaying { get; set; }
        public PlayQueue PlayQueue { get; set; }
        public VideoConversion VideoConversion { get; set; }
        public PodcastChannel PodcastChannel { get; set; }
        public MediaType PodcastStatus { get; set; }
        public MediaType MediaType { get; set; }
        public MediaType ResponseStatus { get; set; }
    }


    public partial class AnyOf
    {
        public string Type { get; set; }
        public AnyOfProperties Properties { get; set; }
        public Name ElementName { get; set; }
    }

    public partial class Name
    {
        public string LocalPart { get; set; }
        public string NamespaceUri { get; set; }
    }

    public partial class AnyOfProperties
    {
        public NameClass Name { get; set; }
        public Value Value { get; set; }
    }

    public partial class NameClass
    {
        public NameAllOf[] AllOf { get; set; }
    }

    public partial class NameAllOf
    {
        public Uri Ref { get; set; }
        public string Type { get; set; }
        public PurpleProperties Properties { get; set; }
    }

    public partial class PurpleProperties
    {
        public LocalPart LocalPart { get; set; }
        public LocalPart NamespaceUri { get; set; }
    }

    public partial class LocalPart
    {
        public string[] Enum { get; set; }
    }

    public partial class Value
    {
        public string Ref { get; set; }
    }

    public partial class AlbumId3
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] AlbumId3Required { get; set; }
        public AlbumId3Properties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class AlbumId3Properties
    {
        public Artist Id { get; set; }
        public Artist Name { get; set; }
        public Artist Artist { get; set; }
        public Artist ArtistId { get; set; }
        public Artist CoverArt { get; set; }
        public Artist SongCount { get; set; }
        public Artist Duration { get; set; }
        public Artist PlayCount { get; set; }
        public Artist Created { get; set; }
        public Artist Starred { get; set; }
        public Artist Year { get; set; }
        public Artist Genre { get; set; }
    }

    public partial class Artist
    {
        public string Title { get; set; }
        public Value[] AllOf { get; set; }
        public PropertyType PropertyType { get; set; }
        public Name AttributeName { get; set; }
        public Name ElementName { get; set; }
    }

    public partial class AlbumInfo
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public AlbumInfoProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class AlbumInfoProperties
    {
        public Artist Notes { get; set; }
        public Artist MusicBrainzId { get; set; }
        public Artist LastFmUrl { get; set; }
        public Artist SmallImageUrl { get; set; }
        public Artist MediumImageUrl { get; set; }
        public Artist LargeImageUrl { get; set; }
        public Artist Biography { get; set; }
    }

    public partial class AlbumList
    {
        public List<Child2> Albums { get; set; }
    }

    public partial class AlbumListProperties
    {
        public Album Album { get; set; }
    }

    public partial class Album
    {
        public string Title { get; set; }
        public AlbumAllOf[] AllOf { get; set; }
        public PropertyType PropertyType { get; set; }
        public Name ElementName { get; set; }
    }

    public partial class AlbumAllOf
    {
        public TypeEnum Type { get; set; }
        public Value Items { get; set; }
        public long MinItems { get; set; }
    }

    public partial class AlbumWithSongsId3
    {
        public AlbumWithSongsId3AllOf[] AllOf { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public PropertiesOrder[] PropertiesOrder { get; set; }
    }

    public partial class AlbumWithSongsId3AllOf
    {
        public string Ref { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public SimilarSongsProperties Properties { get; set; }
    }

    public partial class SimilarSongsProperties
    {
        public Album Song { get; set; }
    }

    public partial class ArtistClass
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] ArtistRequired { get; set; }
        public ArtistProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class ArtistProperties
    {
        public Artist Id { get; set; }
        public Artist Name { get; set; }
        public Artist ArtistImageUrl { get; set; }
        public Artist Starred { get; set; }
        public Artist UserRating { get; set; }
        public Artist AverageRating { get; set; }
    }

    public partial class ArtistId3
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] ArtistId3Required { get; set; }
        public ArtistId3Properties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class ArtistId3Properties
    {
        public Artist Id { get; set; }
        public Artist Name { get; set; }
        public Artist CoverArt { get; set; }
        public Artist ArtistImageUrl { get; set; }
        public Artist AlbumCount { get; set; }
        public Artist Starred { get; set; }
    }

    public partial class ArtistInfo
    {
        public ArtistInfoAllOf[] AllOf { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class ArtistInfoAllOf
    {
        public string Ref { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public FluffyProperties Properties { get; set; }
    }

    public partial class FluffyProperties
    {
        public Album SimilarArtist { get; set; }
    }

    public partial class ArtistWithAlbumsId3
    {
        public ArtistWithAlbumsId3AllOf[] AllOf { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public PropertiesOrder[] PropertiesOrder { get; set; }
    }

    public partial class ArtistWithAlbumsId3AllOf
    {
        public string Ref { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public AlbumListProperties Properties { get; set; }
    }

    public partial class ArtistsId3
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] ArtistsId3Required { get; set; }
        public ArtistsId3Properties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class ArtistsId3Properties
    {
        public Album Index { get; set; }
        public Artist IgnoredArticles { get; set; }
    }

    public partial class AudioTrack
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] AudioTrackRequired { get; set; }
        public AudioTrackProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class AudioTrackProperties
    {
        public Artist Id { get; set; }
        public Artist Name { get; set; }
        public Artist LanguageCode { get; set; }
    }

    public partial class Bookmark
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] BookmarkRequired { get; set; }
        public BookmarkProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class BookmarkProperties
    {
        public Artist Entry { get; set; }
        public Artist Position { get; set; }
        public Artist Username { get; set; }
        public Artist Comment { get; set; }
        public Artist Created { get; set; }
        public Artist Changed { get; set; }
    }

    public partial class Bookmarks
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public BookmarksProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class BookmarksProperties
    {
        public Album Bookmark { get; set; }
    }

    public partial class Captions
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] CaptionsRequired { get; set; }
        public CaptionsProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class CaptionsProperties
    {
        public Artist Id { get; set; }
        public Artist Name { get; set; }
    }

    public partial class ChatMessage
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] ChatMessageRequired { get; set; }
        public ChatMessageProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class ChatMessageProperties
    {
        public Artist Username { get; set; }
        public Artist Time { get; set; }
        public Artist Message { get; set; }
    }

    public partial class ChatMessages
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public ChatMessagesProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class ChatMessagesProperties
    {
        public Album ChatMessage { get; set; }
    }

    public partial class Child2
    {
        private string idField;
        
        private string parentField;
        
        private bool isDirField;
        
        private string titleField;
        
        private string albumField;
        
        private string artistField;
        
        private int trackField;
        
        private bool trackFieldSpecified;
        
        private int yearField;
        
        private bool yearFieldSpecified;
        
        private string genreField;
        
        private string coverArtField;
        
        private long sizeField;
        
        private bool sizeFieldSpecified;
        
        private string contentTypeField;
        
        private string suffixField;
        
        private string transcodedContentTypeField;
        
        private string transcodedSuffixField;
        
        private int durationField;
        
        private bool durationFieldSpecified;
        
        private int bitRateField;
        
        private bool bitRateFieldSpecified;
        
        private string pathField;
        
        private bool isVideoField;
        
        private bool isVideoFieldSpecified;
        
        private int userRatingField;
        
        private bool userRatingFieldSpecified;
        
        private double averageRatingField;
        
        private bool averageRatingFieldSpecified;
        
        private long playCountField;
        
        private bool playCountFieldSpecified;
        
        private int discNumberField;
        
        private bool discNumberFieldSpecified;
        
        private System.DateTime createdField;
        
        private bool createdFieldSpecified;
        
        private System.DateTime starredField;
        
        private bool starredFieldSpecified;
        
        private string albumIdField;
        
        private string artistIdField;
        
        private MediaType2 typeField;
        
        private bool typeFieldSpecified;
        
        private long bookmarkPositionField;
        
        private bool bookmarkPositionFieldSpecified;
        
        private int originalWidthField;
        
        private bool originalWidthFieldSpecified;
        
        private int originalHeightField;
        
        private bool originalHeightFieldSpecified;
        
        
        [JsonPropertyName("id")]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        
        [JsonPropertyName("parent")]
        public string parent {
            get {
                return this.parentField;
            }
            set {
                this.parentField = value;
            }
        }
        
        
        [JsonPropertyName("isDir")]
        public bool isDir {
            get {
                return this.isDirField;
            }
            set {
                this.isDirField = value;
            }
        }
        
        
        [JsonPropertyName("title")]
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        
        
        public string album {
            get {
                return this.albumField;
            }
            set {
                this.albumField = value;
            }
        }
        
        
        
        public string artist {
            get {
                return this.artistField;
            }
            set {
                this.artistField = value;
            }
        }
        
        
        
        public int track {
            get {
                return this.trackField;
            }
            set {
                this.trackField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool trackSpecified {
            get {
                return this.trackFieldSpecified;
            }
            set {
                this.trackFieldSpecified = value;
            }
        }
        
        
        
        public int year {
            get {
                return this.yearField;
            }
            set {
                this.yearField = value;
            }
        }
        
        
        public bool yearSpecified {
            get {
                return this.yearFieldSpecified;
            }
            set {
                this.yearFieldSpecified = value;
            }
        }
        
        
        
        public string genre {
            get {
                return this.genreField;
            }
            set {
                this.genreField = value;
            }
        }
        
        
        [JsonPropertyName("covertArt")]
        public string coverArt {
            get {
                return this.coverArtField;
            }
            set {
                this.coverArtField = value;
            }
        }
        
        
        
        public long size {
            get {
                return this.sizeField;
            }
            set {
                this.sizeField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool sizeSpecified {
            get {
                return this.sizeFieldSpecified;
            }
            set {
                this.sizeFieldSpecified = value;
            }
        }
        
        
        
        public string contentType {
            get {
                return this.contentTypeField;
            }
            set {
                this.contentTypeField = value;
            }
        }
        
        
        
        public string suffix {
            get {
                return this.suffixField;
            }
            set {
                this.suffixField = value;
            }
        }
        
        
        
        public string transcodedContentType {
            get {
                return this.transcodedContentTypeField;
            }
            set {
                this.transcodedContentTypeField = value;
            }
        }
        
        
        
        public string transcodedSuffix {
            get {
                return this.transcodedSuffixField;
            }
            set {
                this.transcodedSuffixField = value;
            }
        }
        
        
        
        public int duration {
            get {
                return this.durationField;
            }
            set {
                this.durationField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool durationSpecified {
            get {
                return this.durationFieldSpecified;
            }
            set {
                this.durationFieldSpecified = value;
            }
        }
        
        
        
        public int bitRate {
            get {
                return this.bitRateField;
            }
            set {
                this.bitRateField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool bitRateSpecified {
            get {
                return this.bitRateFieldSpecified;
            }
            set {
                this.bitRateFieldSpecified = value;
            }
        }
        
        
        
        public string path {
            get {
                return this.pathField;
            }
            set {
                this.pathField = value;
            }
        }
        
        
        
        public bool isVideo {
            get {
                return this.isVideoField;
            }
            set {
                this.isVideoField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool isVideoSpecified {
            get {
                return this.isVideoFieldSpecified;
            }
            set {
                this.isVideoFieldSpecified = value;
            }
        }
        
        
        
        public int userRating {
            get {
                return this.userRatingField;
            }
            set {
                this.userRatingField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool userRatingSpecified {
            get {
                return this.userRatingFieldSpecified;
            }
            set {
                this.userRatingFieldSpecified = value;
            }
        }
        
        
        
        public double averageRating {
            get {
                return this.averageRatingField;
            }
            set {
                this.averageRatingField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool averageRatingSpecified {
            get {
                return this.averageRatingFieldSpecified;
            }
            set {
                this.averageRatingFieldSpecified = value;
            }
        }
        
        
        
        public long playCount {
            get {
                return this.playCountField;
            }
            set {
                this.playCountField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool playCountSpecified {
            get {
                return this.playCountFieldSpecified;
            }
            set {
                this.playCountFieldSpecified = value;
            }
        }
        
        
        
        public int discNumber {
            get {
                return this.discNumberField;
            }
            set {
                this.discNumberField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool discNumberSpecified {
            get {
                return this.discNumberFieldSpecified;
            }
            set {
                this.discNumberFieldSpecified = value;
            }
        }
        
        
        
        public System.DateTime created {
            get {
                return this.createdField;
            }
            set {
                this.createdField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool createdSpecified {
            get {
                return this.createdFieldSpecified;
            }
            set {
                this.createdFieldSpecified = value;
            }
        }
        
        
        
        public System.DateTime starred {
            get {
                return this.starredField;
            }
            set {
                this.starredField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool starredSpecified {
            get {
                return this.starredFieldSpecified;
            }
            set {
                this.starredFieldSpecified = value;
            }
        }
        
        
        
        public string albumId {
            get {
                return this.albumIdField;
            }
            set {
                this.albumIdField = value;
            }
        }
        
        
        
        public string artistId {
            get {
                return this.artistIdField;
            }
            set {
                this.artistIdField = value;
            }
        }
        
        
        
        public MediaType2 type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool typeSpecified {
            get {
                return this.typeFieldSpecified;
            }
            set {
                this.typeFieldSpecified = value;
            }
        }
        
        
        
        public long bookmarkPosition {
            get {
                return this.bookmarkPositionField;
            }
            set {
                this.bookmarkPositionField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool bookmarkPositionSpecified {
            get {
                return this.bookmarkPositionFieldSpecified;
            }
            set {
                this.bookmarkPositionFieldSpecified = value;
            }
        }
        
        
        
        public int originalWidth {
            get {
                return this.originalWidthField;
            }
            set {
                this.originalWidthField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool originalWidthSpecified {
            get {
                return this.originalWidthFieldSpecified;
            }
            set {
                this.originalWidthFieldSpecified = value;
            }
        }
        
        
        
        public int originalHeight {
            get {
                return this.originalHeightField;
            }
            set {
                this.originalHeightField = value;
            }
        }
        
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool originalHeightSpecified {
            get {
                return this.originalHeightFieldSpecified;
            }
            set {
                this.originalHeightFieldSpecified = value;
            }
        }
    }
    

    public partial class Directory
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] DirectoryRequired { get; set; }
        public DirectoryProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class DirectoryProperties
    {
        public Album Child { get; set; }
        public Artist Id { get; set; }
        public Artist Parent { get; set; }
        public Artist Name { get; set; }
        public Artist Starred { get; set; }
        public Artist UserRating { get; set; }
        public Artist AverageRating { get; set; }
        public Artist PlayCount { get; set; }
    }

    public partial class Error
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    public partial class Genre
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] GenreRequired { get; set; }
        public GenreProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class GenreProperties
    {
        public Artist Content { get; set; }
        public Artist SongCount { get; set; }
        public Artist AlbumCount { get; set; }
    }

    public partial class Genres
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public GenresProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class GenresProperties
    {
        public Album Genre { get; set; }
    }

    public partial class Index
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] IndexRequired { get; set; }
        public IndexProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class IndexProperties
    {
        public Album Artist { get; set; }
        public Artist Name { get; set; }
    }

    public partial class Indexes
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] IndexesRequired { get; set; }
        public IndexesProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class IndexesProperties
    {
        public Album Shortcut { get; set; }
        public Album Index { get; set; }
        public Album Child { get; set; }
        public Artist LastModified { get; set; }
        public Artist IgnoredArticles { get; set; }
    }

    public partial class InternetRadioStation
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] InternetRadioStationRequired { get; set; }
        public InternetRadioStationProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class InternetRadioStationProperties
    {
        public Artist Id { get; set; }
        public Artist Name { get; set; }
        public Artist StreamUrl { get; set; }
        public Artist HomePageUrl { get; set; }
    }

    public partial class InternetRadioStations
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public InternetRadioStationsProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class InternetRadioStationsProperties
    {
        public Album InternetRadioStation { get; set; }
    }

    public partial class JukeboxPlaylist
    {
        public JukeboxPlaylistAllOf[] AllOf { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class JukeboxPlaylistAllOf
    {
        public string Ref { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public NowPlayingProperties Properties { get; set; }
    }

    public partial class NowPlayingProperties
    {
        public Album Entry { get; set; }
    }

    public partial class JukeboxStatus
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] JukeboxStatusRequired { get; set; }
        public JukeboxStatusProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class JukeboxStatusProperties
    {
        public Artist CurrentIndex { get; set; }
        public Artist Playing { get; set; }
        public Artist Gain { get; set; }
        public Artist Position { get; set; }
    }

    public partial class License
    {
        [JsonPropertyName("valid")]
        public bool Valid { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    public partial class Lyrics
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public LyricsProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class LyricsProperties
    {
        public Artist Content { get; set; }
        public Artist Artist { get; set; }
        public Artist Title { get; set; }
    }

    public partial class MediaType
    {
        public MediaTypeAllOf[] AllOf { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
    }

    public partial class MediaTypeAllOf
    {
        public Uri Ref { get; set; }
        public string[] Enum { get; set; }
    }

    public partial class MusicFolders
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public MusicFoldersProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class MusicFoldersProperties
    {
        public Album MusicFolder { get; set; }
    }

    public partial class NewestPodcasts
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public NewestPodcastsProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class NewestPodcastsProperties
    {
        public Album Episode { get; set; }
    }

    public partial class NowPlaying
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public NowPlayingProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class NowPlayingEntry
    {
        public string[] NowPlayingEntryRequired { get; set; }
        public NowPlayingEntryAllOf[] AllOf { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class NowPlayingEntryAllOf
    {
        public string Ref { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public TentacledProperties Properties { get; set; }
    }

    public partial class TentacledProperties
    {
        public Artist Username { get; set; }
        public Artist MinutesAgo { get; set; }
        public Artist PlayerId { get; set; }
        public Artist PlayerName { get; set; }
    }

    public partial class PlayQueue
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] PlayQueueRequired { get; set; }
        public PlayQueueProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class PlayQueueProperties
    {
        public Album Entry { get; set; }
        public Artist Current { get; set; }
        public Artist Position { get; set; }
        public Artist Username { get; set; }
        public Artist Changed { get; set; }
        public Artist ChangedBy { get; set; }
    }

    public partial class Playlist
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] PlaylistRequired { get; set; }
        public PlaylistProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class PlaylistProperties
    {
        public Album AllowedUser { get; set; }
        public Artist Id { get; set; }
        public Artist Name { get; set; }
        public Artist Comment { get; set; }
        public Artist Owner { get; set; }
        public Artist Public { get; set; }
        public Artist SongCount { get; set; }
        public Artist Duration { get; set; }
        public Artist Created { get; set; }
        public Artist Changed { get; set; }
        public Artist CoverArt { get; set; }
    }

    public partial class Playlists
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public PlaylistsProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class PlaylistsProperties
    {
        public Album Playlist { get; set; }
    }

    public partial class PodcastChannel
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] PodcastChannelRequired { get; set; }
        public PodcastChannelProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class PodcastChannelProperties
    {
        public Album Episode { get; set; }
        public Artist Id { get; set; }
        public Artist Url { get; set; }
        public Artist Title { get; set; }
        public Artist Description { get; set; }
        public Artist CoverArt { get; set; }
        public Artist OriginalImageUrl { get; set; }
        public Artist Status { get; set; }
        public Artist ErrorMessage { get; set; }
    }

    public partial class PodcastEpisode
    {
        public string[] PodcastEpisodeRequired { get; set; }
        public PodcastEpisodeAllOf[] AllOf { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class PodcastEpisodeAllOf
    {
        public string Ref { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public StickyProperties Properties { get; set; }
    }

    public partial class StickyProperties
    {
        public Artist StreamId { get; set; }
        public Artist ChannelId { get; set; }
        public Artist Description { get; set; }
        public Artist Status { get; set; }
        public Artist PublishDate { get; set; }
    }

    public partial class Podcasts
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public PodcastsProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class PodcastsProperties
    {
        public Album Channel { get; set; }
    }

    public partial class ScanStatus
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] ScanStatusRequired { get; set; }
        public ScanStatusProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class ScanStatusProperties
    {
        public Artist Scanning { get; set; }
        public Artist Count { get; set; }
    }

    public partial class SearchResult
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] SearchResultRequired { get; set; }
        public SearchResultProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class SearchResultProperties
    {
        public Album Match { get; set; }
        public Artist Offset { get; set; }
        public Artist TotalHits { get; set; }
    }

    public partial class SearchResult2
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public SearchResult2Properties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public PropertiesOrder[] PropertiesOrder { get; set; }
    }

    public partial class SearchResult2Properties
    {
        public Album Artist { get; set; }
        public Album Album { get; set; }
        public Album Song { get; set; }
    }

    public partial class Share
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] ShareRequired { get; set; }
        public ShareProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class ShareProperties
    {
        public Album Entry { get; set; }
        public Artist Id { get; set; }
        public Artist Url { get; set; }
        public Artist Description { get; set; }
        public Artist Username { get; set; }
        public Artist Created { get; set; }
        public Artist Expires { get; set; }
        public Artist LastVisited { get; set; }
        public Artist VisitCount { get; set; }
    }

    public partial class Shares
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public SharesProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class SharesProperties
    {
        public Album Share { get; set; }
    }

    public partial class SimilarSongs
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public SimilarSongsProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public PropertiesOrder[] PropertiesOrder { get; set; }
    }

    public partial class User
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] UserRequired { get; set; }
        public UserProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class UserProperties
    {
        public Album Folder { get; set; }
        public Artist Username { get; set; }
        public Artist Email { get; set; }
        public Artist ScrobblingEnabled { get; set; }
        public Artist MaxBitRate { get; set; }
        public Artist AdminRole { get; set; }
        public Artist SettingsRole { get; set; }
        public Artist DownloadRole { get; set; }
        public Artist UploadRole { get; set; }
        public Artist PlaylistRole { get; set; }
        public Artist CoverArtRole { get; set; }
        public Artist CommentRole { get; set; }
        public Artist PodcastRole { get; set; }
        public Artist StreamRole { get; set; }
        public Artist JukeboxRole { get; set; }
        public Artist ShareRole { get; set; }
        public Artist VideoConversionRole { get; set; }
        public Artist AvatarLastChanged { get; set; }
    }

    public partial class Users
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public UsersProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class UsersProperties
    {
        public Album User { get; set; }
    }

    public partial class VideoConversion
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] VideoConversionRequired { get; set; }
        public VideoConversionProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class VideoConversionProperties
    {
        public Artist Id { get; set; }
        public Artist BitRate { get; set; }
        public Artist AudioTrackId { get; set; }
    }

    public partial class VideoInfo
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string[] VideoInfoRequired { get; set; }
        public VideoInfoProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class VideoInfoProperties
    {
        public Album Captions { get; set; }
        public Album AudioTrack { get; set; }
        public Album Conversion { get; set; }
        public Artist Id { get; set; }
    }

    public partial class Videos
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public VideosProperties Properties { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
        public string[] PropertiesOrder { get; set; }
    }

    public partial class VideosProperties
    {
        public Album Video { get; set; }
    }

    public enum PropertyType { Attribute, Element, Value };

    public enum TypeEnum { Array };

    public enum PropertiesOrder { Album, Artist, Song };
}
