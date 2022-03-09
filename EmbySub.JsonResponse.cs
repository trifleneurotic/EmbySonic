using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmbySub
{

    public partial class JsonResponse : Response
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
        public ArtistsID3Json ArtistsID3 { get; set; }

        [JsonPropertyName("error")]
        public ErrorJson Error { get; set; }
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
        public SimilarSongs SimilarSongs2 { get; set; }
        public Genre Genre { get; set; }
        public ArtistInfo ArtistInfo2 { get; set; }
        public IndexJson Index { get; set; }
        public ArtistId3 ArtistId3 { get; set; }
        public AudioTrack AudioTrack { get; set; }
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

        [JsonPropertyName("albumList2")]
        public AlbumListJson AlbumList2 { get; set; }
        [JsonPropertyName("albumList")]
        public AlbumListJson AlbumList { get; set; }
        public Child2 Child { get; set; }
        public Podcasts Podcasts { get; set; }
        public IndexJson IndexId3 { get; set; }
        public ChatMessage ChatMessage { get; set; }
        public ArtistClass Artist { get; set; }
        public NowPlaying NowPlaying { get; set; }
        public PlayQueue PlayQueue { get; set; }
        public VideoConversion VideoConversion { get; set; }
        public PodcastChannel PodcastChannel { get; set; }
        public MediaType2 PodcastStatus { get; set; }
        public MediaType2 MediaType { get; set; }
        public MediaType2 ResponseStatus { get; set; }
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

    public partial class AlbumListJson
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
        public Name ElementName { get; set; }
    }

    

    public partial class AlbumWithSongsId3
    {
        public AlbumWithSongsId3AllOf[] AllOf { get; set; }
        public string TypeType { get; set; }
        public Name TypeName { get; set; }
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
    public partial class ArtistsID3Json
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
        
        
        [JsonPropertyName("coverArt")]
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

    public partial class ErrorJson
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

    public partial class IndexJson
    {
        private ArtistId3[] artistField;
        
        private string nameField;
    
        public ArtistId3[] artist {
            get {
                return this.artistField;
            }
            set {
                this.artistField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        
    }
    }

    public partial class LicenseJson
    {
        [JsonPropertyName("valid")]
        public bool Valid { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

}
