using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmbySonic
{
    using System.Xml.Serialization;


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    [System.Xml.Serialization.XmlRootAttribute("subsonic-response", Namespace = "http://subsonic.org/restapi", IsNullable = false)]
    public partial class Response
    {

        private object itemField;
        private ItemChoiceType itemElementNameField;
        private ResponseStatus statusField;
        private string versionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("album", typeof(AlbumWithSongsID3))]
        [System.Xml.Serialization.XmlElementAttribute("albumInfo", typeof(AlbumInfo))]
        [System.Xml.Serialization.XmlElementAttribute("albumList", typeof(AlbumList))]
        [System.Xml.Serialization.XmlElementAttribute("albumList2", typeof(AlbumListID3))]
        [System.Xml.Serialization.XmlElementAttribute("artist", typeof(ArtistWithAlbumsID3))]
        [System.Xml.Serialization.XmlElementAttribute("artistInfo", typeof(ArtistInfo))]
        [System.Xml.Serialization.XmlElementAttribute("artistInfo2", typeof(ArtistInfo2))]
        [System.Xml.Serialization.XmlElementAttribute("artists", typeof(ArtistsID3))]
        [System.Xml.Serialization.XmlElementAttribute("bookmarks", typeof(Bookmarks))]
        [System.Xml.Serialization.XmlElementAttribute("chatMessages", typeof(ChatMessages))]
        [System.Xml.Serialization.XmlElementAttribute("directory", typeof(Directory))]
        [System.Xml.Serialization.XmlElementAttribute("error", typeof(Error))]
        [System.Xml.Serialization.XmlElementAttribute("genres", typeof(Genres))]
        [System.Xml.Serialization.XmlElementAttribute("indexes", typeof(Indexes))]
        [System.Xml.Serialization.XmlElementAttribute("internetRadioStations", typeof(InternetRadioStations))]
        [System.Xml.Serialization.XmlElementAttribute("jukeboxPlaylist", typeof(JukeboxPlaylist))]
        [System.Xml.Serialization.XmlElementAttribute("jukeboxStatus", typeof(JukeboxStatus))]
        [System.Xml.Serialization.XmlElementAttribute("license", typeof(License))]
        [System.Xml.Serialization.XmlElementAttribute("lyrics", typeof(Lyrics))]
        [System.Xml.Serialization.XmlElementAttribute("musicFolders", typeof(MusicFolders))]
        [System.Xml.Serialization.XmlElementAttribute("newestPodcasts", typeof(NewestPodcasts))]
        [System.Xml.Serialization.XmlElementAttribute("nowPlaying", typeof(NowPlaying))]
        [System.Xml.Serialization.XmlElementAttribute("playQueue", typeof(PlayQueue))]
        [System.Xml.Serialization.XmlElementAttribute("playlist", typeof(PlaylistWithSongs))]
        [System.Xml.Serialization.XmlElementAttribute("playlists", typeof(Playlists))]
        [System.Xml.Serialization.XmlElementAttribute("podcasts", typeof(Podcasts))]
        [System.Xml.Serialization.XmlElementAttribute("randomSongs", typeof(Songs))]
        [System.Xml.Serialization.XmlElementAttribute("scanStatus", typeof(ScanStatus))]
        [System.Xml.Serialization.XmlElementAttribute("searchResult", typeof(SearchResult))]
        [System.Xml.Serialization.XmlElementAttribute("searchResult2", typeof(SearchResult2))]
        [System.Xml.Serialization.XmlElementAttribute("searchResult3", typeof(SearchResult3))]
        [System.Xml.Serialization.XmlElementAttribute("shares", typeof(Shares))]
        [System.Xml.Serialization.XmlElementAttribute("similarSongs", typeof(SimilarSongs))]
        [System.Xml.Serialization.XmlElementAttribute("similarSongs2", typeof(SimilarSongs2))]
        [System.Xml.Serialization.XmlElementAttribute("song", typeof(Child))]
        [System.Xml.Serialization.XmlElementAttribute("songsByGenre", typeof(Songs))]
        [System.Xml.Serialization.XmlElementAttribute("starred", typeof(Starred))]
        [System.Xml.Serialization.XmlElementAttribute("starred2", typeof(Starred2))]
        [System.Xml.Serialization.XmlElementAttribute("topSongs", typeof(TopSongs))]
        [System.Xml.Serialization.XmlElementAttribute("user", typeof(User))]
        [System.Xml.Serialization.XmlElementAttribute("users", typeof(Users))]
        [System.Xml.Serialization.XmlElementAttribute("videoInfo", typeof(VideoInfo))]
        [System.Xml.Serialization.XmlElementAttribute("videos", typeof(Videos))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]

        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        [JsonPropertyName("album")]
        public AlbumWithSongsID3 album { set { Item = value; } }

        [JsonPropertyName("albumInfo")]
        public AlbumInfo albumInfo { set { Item = value; } }
        [JsonPropertyName("albumList")]
        public AlbumList albumList { set { Item = value; } }
        [JsonPropertyName("albumList2")]
        public AlbumListID3 albumList2 { set { Item = value; } }
        [JsonPropertyName("artist")]
        public ArtistWithAlbumsID3 artist { set { Item = value; } }
        [JsonPropertyName("artistInfo")]
        public ArtistInfo artistInfo { set { Item = value; } }
        [JsonPropertyName("artistInfo2")]
        public ArtistInfo2 artistInfo2 { set { Item = value; } }
        [JsonPropertyName("artists")]
        public ArtistsID3 artists { set { Item = value; } }
        [JsonPropertyName("bookmarks")]
        public Bookmarks bookmarks { set { Item = value; } }
        [JsonPropertyName("chatMessages")]
        public ChatMessages chatMessages { set { Item = value; } }
        [JsonPropertyName("directory")]
        public Directory directory { set { Item = value; } }
        [JsonPropertyName("error")]
        public Error error { set { Item = value; } }
        [JsonPropertyName("genres")]
        public Genres genres { set { Item = value; } }
        [JsonPropertyName("indexes")]
        public Indexes indexes { set { Item = value; } }
        [JsonPropertyName("internetRadioStations")]
        public InternetRadioStations internetRadioStations { set { Item = value; } }
        [JsonPropertyName("jukeboxPlaylist")]
        public JukeboxPlaylist jukeboxPlaylist { set { Item = value; } }
        [JsonPropertyName("jukeboxStatus")]
        public JukeboxStatus jukeboxStatus { set { Item = value; } }
        [JsonPropertyName("license")]
        public License license { set { Item = value; } }
        [JsonPropertyName("lyrics")]
        public Lyrics lyrics { set { Item = value; } }
        [JsonPropertyName("musicFolders")]
        public MusicFolders musicFolders { set { Item = value; } }
        [JsonPropertyName("newestPodcasts")]
        public NewestPodcasts newestPodcasts { set { Item = value; } }
        [JsonPropertyName("nowPlaying")]
        public NowPlaying nowPlaying { set { Item = value; } }
        [JsonPropertyName("playQueue")]
        public PlayQueue playQueue { set { Item = value; } }
        [JsonPropertyName("playlist")]
        public Playlist playlist { set { Item = value; } }
        [JsonPropertyName("playlists")]
        public Playlists playlists { set { Item = value; } }
        [JsonPropertyName("podcasts")]
        public Podcasts podcasts { set { Item = value; } }
        [JsonPropertyName("randomSongs")]
        public Songs randomSongs { set { Item = value; } }
        [JsonPropertyName("scanStatus")]
        public ScanStatus scanStatus { set { Item = value; } }
        [JsonPropertyName("searchResult")]
        public SearchResult searchResult { set { Item = value; } }
        [JsonPropertyName("searchResult2")]
        public SearchResult searchResult2 { set { Item = value; } }
        [JsonPropertyName("shares")]
        public Shares shares { set { Item = value; } }
        [JsonPropertyName("similarSongs")]
        public SimilarSongs similarSongs { set { Item = value; } }
        [JsonPropertyName("similarSongs2")]
        public SimilarSongs2 similarSongs2 { set { Item = value; } }
        [JsonPropertyName("song")]
        public Child song { set { Item = value; } }
        [JsonPropertyName("songsByGenre")]
        public Songs songsByGenre { set { Item = value; } }
        [JsonPropertyName("starred")]
        public Starred starred { set { Item = value; } }
        [JsonPropertyName("starred2")]
        public Starred2 starred2 { set { Item = value; } }
        [JsonPropertyName("topSongs")]
        public TopSongs topSongs { set { Item = value; } }
        [JsonPropertyName("user")]
        public User user { set { Item = value; } }
        [JsonPropertyName("users")]
        public Users users { set { Item = value; } }
        [JsonPropertyName("videoInfo")]
        public VideoInfo videoInfo { set { Item = value; } }
        [JsonPropertyName("videos")]
        public Videos videos { set { Item = value; } }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public ItemChoiceType ItemElementName
        {
            get
            {
                return this.itemElementNameField;
            }
            set
            {
                this.itemElementNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public ResponseStatus status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class AlbumWithSongsID3 : AlbumID3
    {

        private Child[] songField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("song")]
        public Child[] song
        {
            get
            {
                return this.songField;
            }
            set
            {
                this.songField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PodcastEpisode))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NowPlayingEntry))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Child
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonPropertyName("id")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonPropertyName("parent")]
        public string parent
        {
            get
            {
                return this.parentField;
            }
            set
            {
                this.parentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonPropertyName("isDir")]
        public bool isDir
        {
            get
            {
                return this.isDirField;
            }
            set
            {
                this.isDirField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonPropertyName("title")]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonPropertyName("album")]
        public string album
        {
            get
            {
                return this.albumField;
            }
            set
            {
                this.albumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonPropertyName("artist")]
        public string artist
        {
            get
            {
                return this.artistField;
            }
            set
            {
                this.artistField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int track
        {
            get
            {
                return this.trackField;
            }
            set
            {
                this.trackField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool trackSpecified
        {
            get
            {
                return this.trackFieldSpecified;
            }
            set
            {
                this.trackFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int year
        {
            get
            {
                return this.yearField;
            }
            set
            {
                this.yearField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool yearSpecified
        {
            get
            {
                return this.yearFieldSpecified;
            }
            set
            {
                this.yearFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string genre
        {
            get
            {
                return this.genreField;
            }
            set
            {
                this.genreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonPropertyName("coverArt")]
        public string coverArt
        {
            get
            {
                return this.coverArtField;
            }
            set
            {
                this.coverArtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public long size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool sizeSpecified
        {
            get
            {
                return this.sizeFieldSpecified;
            }
            set
            {
                this.sizeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string contentType
        {
            get
            {
                return this.contentTypeField;
            }
            set
            {
                this.contentTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string suffix
        {
            get
            {
                return this.suffixField;
            }
            set
            {
                this.suffixField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string transcodedContentType
        {
            get
            {
                return this.transcodedContentTypeField;
            }
            set
            {
                this.transcodedContentTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string transcodedSuffix
        {
            get
            {
                return this.transcodedSuffixField;
            }
            set
            {
                this.transcodedSuffixField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool durationSpecified
        {
            get
            {
                return this.durationFieldSpecified;
            }
            set
            {
                this.durationFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int bitRate
        {
            get
            {
                return this.bitRateField;
            }
            set
            {
                this.bitRateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool bitRateSpecified
        {
            get
            {
                return this.bitRateFieldSpecified;
            }
            set
            {
                this.bitRateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string path
        {
            get
            {
                return this.pathField;
            }
            set
            {
                this.pathField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool isVideo
        {
            get
            {
                return this.isVideoField;
            }
            set
            {
                this.isVideoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool isVideoSpecified
        {
            get
            {
                return this.isVideoFieldSpecified;
            }
            set
            {
                this.isVideoFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int userRating
        {
            get
            {
                return this.userRatingField;
            }
            set
            {
                this.userRatingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool userRatingSpecified
        {
            get
            {
                return this.userRatingFieldSpecified;
            }
            set
            {
                this.userRatingFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public double averageRating
        {
            get
            {
                return this.averageRatingField;
            }
            set
            {
                this.averageRatingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool averageRatingSpecified
        {
            get
            {
                return this.averageRatingFieldSpecified;
            }
            set
            {
                this.averageRatingFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public long playCount
        {
            get
            {
                return this.playCountField;
            }
            set
            {
                this.playCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool playCountSpecified
        {
            get
            {
                return this.playCountFieldSpecified;
            }
            set
            {
                this.playCountFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int discNumber
        {
            get
            {
                return this.discNumberField;
            }
            set
            {
                this.discNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool discNumberSpecified
        {
            get
            {
                return this.discNumberFieldSpecified;
            }
            set
            {
                this.discNumberFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool createdSpecified
        {
            get
            {
                return this.createdFieldSpecified;
            }
            set
            {
                this.createdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime starred
        {
            get
            {
                return this.starredField;
            }
            set
            {
                this.starredField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool starredSpecified
        {
            get
            {
                return this.starredFieldSpecified;
            }
            set
            {
                this.starredFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string albumId
        {
            get
            {
                return this.albumIdField;
            }
            set
            {
                this.albumIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string artistId
        {
            get
            {
                return this.artistIdField;
            }
            set
            {
                this.artistIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public MediaType2 type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool typeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public long bookmarkPosition
        {
            get
            {
                return this.bookmarkPositionField;
            }
            set
            {
                this.bookmarkPositionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool bookmarkPositionSpecified
        {
            get
            {
                return this.bookmarkPositionFieldSpecified;
            }
            set
            {
                this.bookmarkPositionFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int originalWidth
        {
            get
            {
                return this.originalWidthField;
            }
            set
            {
                this.originalWidthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool originalWidthSpecified
        {
            get
            {
                return this.originalWidthFieldSpecified;
            }
            set
            {
                this.originalWidthFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int originalHeight
        {
            get
            {
                return this.originalHeightField;
            }
            set
            {
                this.originalHeightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool originalHeightSpecified
        {
            get
            {
                return this.originalHeightFieldSpecified;
            }
            set
            {
                this.originalHeightFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public enum MediaType2
    {

        /// <remarks/>
        music,

        /// <remarks/>
        podcast,

        /// <remarks/>
        audiobook,

        /// <remarks/>
        video,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Error
    {

        private int codeField;

        private string messageField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonPropertyName("code")]
        public int code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonPropertyName("message")]
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class ScanStatus
    {

        private bool scanningField;

        private long countField;

        private bool countFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool scanning
        {
            get
            {
                return this.scanningField;
            }
            set
            {
                this.scanningField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public long count
        {
            get
            {
                return this.countField;
            }
            set
            {
                this.countField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool countSpecified
        {
            get
            {
                return this.countFieldSpecified;
            }
            set
            {
                this.countFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class TopSongs
    {

        private Child[] songField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("song")]
        public Child[] song
        {
            get
            {
                return this.songField;
            }
            set
            {
                this.songField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class SimilarSongs2
    {

        private Child[] songField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("song")]
        public Child[] song
        {
            get
            {
                return this.songField;
            }
            set
            {
                this.songField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class SimilarSongs
    {

        private Child[] songField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("song")]
        public Child[] song
        {
            get
            {
                return this.songField;
            }
            set
            {
                this.songField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ArtistInfo2))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ArtistInfo))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class ArtistInfoBase
    {

        private string biographyField;

        private string musicBrainzIdField;

        private string lastFmUrlField;

        private string smallImageUrlField;

        private string mediumImageUrlField;

        private string largeImageUrlField;

        /// <remarks/>
        public string biography
        {
            get
            {
                return this.biographyField;
            }
            set
            {
                this.biographyField = value;
            }
        }

        /// <remarks/>
        public string musicBrainzId
        {
            get
            {
                return this.musicBrainzIdField;
            }
            set
            {
                this.musicBrainzIdField = value;
            }
        }

        /// <remarks/>
        public string lastFmUrl
        {
            get
            {
                return this.lastFmUrlField;
            }
            set
            {
                this.lastFmUrlField = value;
            }
        }

        /// <remarks/>
        public string smallImageUrl
        {
            get
            {
                return this.smallImageUrlField;
            }
            set
            {
                this.smallImageUrlField = value;
            }
        }

        /// <remarks/>
        public string mediumImageUrl
        {
            get
            {
                return this.mediumImageUrlField;
            }
            set
            {
                this.mediumImageUrlField = value;
            }
        }

        /// <remarks/>
        public string largeImageUrl
        {
            get
            {
                return this.largeImageUrlField;
            }
            set
            {
                this.largeImageUrlField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class ArtistInfo2 : ArtistInfoBase
    {

        private ArtistID3[] similarArtistField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("similarArtist")]
        public ArtistID3[] similarArtist
        {
            get
            {
                return this.similarArtistField;
            }
            set
            {
                this.similarArtistField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ArtistWithAlbumsID3))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class ArtistID3
    {

        private string idField;

        private string nameField;

        private string coverArtField;

        private string artistImageUrlField;

        private int albumCountField;

        private System.DateTime starredField;

        private bool starredFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string coverArt
        {
            get
            {
                return this.coverArtField;
            }
            set
            {
                this.coverArtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string artistImageUrl
        {
            get
            {
                return this.artistImageUrlField;
            }
            set
            {
                this.artistImageUrlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int albumCount
        {
            get
            {
                return this.albumCountField;
            }
            set
            {
                this.albumCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime starred
        {
            get
            {
                return this.starredField;
            }
            set
            {
                this.starredField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool starredSpecified
        {
            get
            {
                return this.starredFieldSpecified;
            }
            set
            {
                this.starredFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class ArtistWithAlbumsID3 : ArtistID3
    {

        private AlbumID3[] albumField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("album")]
        public AlbumID3[] album
        {
            get
            {
                return this.albumField;
            }
            set
            {
                this.albumField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AlbumWithSongsID3))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class AlbumID3
    {

        private string idField;

        private string nameField;

        private string artistField;

        private string artistIdField;

        private string coverArtField;

        private int songCountField;

        private int durationField;

        private long playCountField;

        private bool playCountFieldSpecified;

        private System.DateTime createdField;

        private System.DateTime starredField;

        private bool starredFieldSpecified;

        private int yearField;

        private bool yearFieldSpecified;

        private string genreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string artist
        {
            get
            {
                return this.artistField;
            }
            set
            {
                this.artistField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string artistId
        {
            get
            {
                return this.artistIdField;
            }
            set
            {
                this.artistIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string coverArt
        {
            get
            {
                return this.coverArtField;
            }
            set
            {
                this.coverArtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int songCount
        {
            get
            {
                return this.songCountField;
            }
            set
            {
                this.songCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public long playCount
        {
            get
            {
                return this.playCountField;
            }
            set
            {
                this.playCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool playCountSpecified
        {
            get
            {
                return this.playCountFieldSpecified;
            }
            set
            {
                this.playCountFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime starred
        {
            get
            {
                return this.starredField;
            }
            set
            {
                this.starredField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool starredSpecified
        {
            get
            {
                return this.starredFieldSpecified;
            }
            set
            {
                this.starredFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int year
        {
            get
            {
                return this.yearField;
            }
            set
            {
                this.yearField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool yearSpecified
        {
            get
            {
                return this.yearFieldSpecified;
            }
            set
            {
                this.yearFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string genre
        {
            get
            {
                return this.genreField;
            }
            set
            {
                this.genreField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class ArtistInfo : ArtistInfoBase
    {

        private Artist[] similarArtistField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("similarArtist")]
        public Artist[] similarArtist
        {
            get
            {
                return this.similarArtistField;
            }
            set
            {
                this.similarArtistField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Artist
    {

        private string idField;

        private string nameField;

        private string artistImageUrlField;

        private System.DateTime starredField;

        private bool starredFieldSpecified;

        private int userRatingField;

        private bool userRatingFieldSpecified;

        private double averageRatingField;

        private bool averageRatingFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string artistImageUrl
        {
            get
            {
                return this.artistImageUrlField;
            }
            set
            {
                this.artistImageUrlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime starred
        {
            get
            {
                return this.starredField;
            }
            set
            {
                this.starredField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool starredSpecified
        {
            get
            {
                return this.starredFieldSpecified;
            }
            set
            {
                this.starredFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int userRating
        {
            get
            {
                return this.userRatingField;
            }
            set
            {
                this.userRatingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool userRatingSpecified
        {
            get
            {
                return this.userRatingFieldSpecified;
            }
            set
            {
                this.userRatingFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public double averageRating
        {
            get
            {
                return this.averageRatingField;
            }
            set
            {
                this.averageRatingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool averageRatingSpecified
        {
            get
            {
                return this.averageRatingFieldSpecified;
            }
            set
            {
                this.averageRatingFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class AlbumInfo
    {

        private string notesField;

        private string musicBrainzIdField;

        private string lastFmUrlField;

        private string smallImageUrlField;

        private string mediumImageUrlField;

        private string largeImageUrlField;

        /// <remarks/>
        public string notes
        {
            get
            {
                return this.notesField;
            }
            set
            {
                this.notesField = value;
            }
        }

        /// <remarks/>
        public string musicBrainzId
        {
            get
            {
                return this.musicBrainzIdField;
            }
            set
            {
                this.musicBrainzIdField = value;
            }
        }

        /// <remarks/>
        public string lastFmUrl
        {
            get
            {
                return this.lastFmUrlField;
            }
            set
            {
                this.lastFmUrlField = value;
            }
        }

        /// <remarks/>
        public string smallImageUrl
        {
            get
            {
                return this.smallImageUrlField;
            }
            set
            {
                this.smallImageUrlField = value;
            }
        }

        /// <remarks/>
        public string mediumImageUrl
        {
            get
            {
                return this.mediumImageUrlField;
            }
            set
            {
                this.mediumImageUrlField = value;
            }
        }

        /// <remarks/>
        public string largeImageUrl
        {
            get
            {
                return this.largeImageUrlField;
            }
            set
            {
                this.largeImageUrlField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Starred2
    {

        private ArtistID3[] artistField;

        private AlbumID3[] albumField;

        private Child[] songField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("artist")]
        public ArtistID3[] artist
        {
            get
            {
                return this.artistField;
            }
            set
            {
                this.artistField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("album")]
        public AlbumID3[] album
        {
            get
            {
                return this.albumField;
            }
            set
            {
                this.albumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("song")]
        public Child[] song
        {
            get
            {
                return this.songField;
            }
            set
            {
                this.songField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Starred
    {

        private Artist[] artistField;

        private Child[] albumField;

        private Child[] songField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("artist")]
        public Artist[] artist
        {
            get
            {
                return this.artistField;
            }
            set
            {
                this.artistField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("album")]
        public Child[] album
        {
            get
            {
                return this.albumField;
            }
            set
            {
                this.albumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("song")]
        public Child[] song
        {
            get
            {
                return this.songField;
            }
            set
            {
                this.songField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Shares
    {

        private Share[] shareField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("share")]
        public Share[] share
        {
            get
            {
                return this.shareField;
            }
            set
            {
                this.shareField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Share
    {

        private Child[] entryField;

        private string idField;

        private string urlField;

        private string descriptionField;

        private string usernameField;

        private System.DateTime createdField;

        private System.DateTime expiresField;

        private bool expiresFieldSpecified;

        private System.DateTime lastVisitedField;

        private bool lastVisitedFieldSpecified;

        private int visitCountField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("entry")]
        public Child[] entry
        {
            get
            {
                return this.entryField;
            }
            set
            {
                this.entryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime expires
        {
            get
            {
                return this.expiresField;
            }
            set
            {
                this.expiresField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool expiresSpecified
        {
            get
            {
                return this.expiresFieldSpecified;
            }
            set
            {
                this.expiresFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime lastVisited
        {
            get
            {
                return this.lastVisitedField;
            }
            set
            {
                this.lastVisitedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool lastVisitedSpecified
        {
            get
            {
                return this.lastVisitedFieldSpecified;
            }
            set
            {
                this.lastVisitedFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int visitCount
        {
            get
            {
                return this.visitCountField;
            }
            set
            {
                this.visitCountField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class PlayQueue
    {

        private Child[] entryField;

        private int currentField;

        private bool currentFieldSpecified;

        private long positionField;

        private bool positionFieldSpecified;

        private string usernameField;

        private System.DateTime changedField;

        private string changedByField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("entry")]
        public Child[] entry
        {
            get
            {
                return this.entryField;
            }
            set
            {
                this.entryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int current
        {
            get
            {
                return this.currentField;
            }
            set
            {
                this.currentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool currentSpecified
        {
            get
            {
                return this.currentFieldSpecified;
            }
            set
            {
                this.currentFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public long position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool positionSpecified
        {
            get
            {
                return this.positionFieldSpecified;
            }
            set
            {
                this.positionFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime changed
        {
            get
            {
                return this.changedField;
            }
            set
            {
                this.changedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string changedBy
        {
            get
            {
                return this.changedByField;
            }
            set
            {
                this.changedByField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Bookmarks
    {

        private Bookmark[] bookmarkField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("bookmark")]
        public Bookmark[] bookmark
        {
            get
            {
                return this.bookmarkField;
            }
            set
            {
                this.bookmarkField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Bookmark
    {

        private Child entryField;

        private long positionField;

        private string usernameField;

        private string commentField;

        private System.DateTime createdField;

        private System.DateTime changedField;

        /// <remarks/>
        public Child entry
        {
            get
            {
                return this.entryField;
            }
            set
            {
                this.entryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public long position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime changed
        {
            get
            {
                return this.changedField;
            }
            set
            {
                this.changedField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class InternetRadioStations
    {

        private InternetRadioStation[] internetRadioStationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("internetRadioStation")]
        public InternetRadioStation[] internetRadioStation
        {
            get
            {
                return this.internetRadioStationField;
            }
            set
            {
                this.internetRadioStationField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class InternetRadioStation
    {

        private string idField;

        private string nameField;

        private string streamUrlField;

        private string homePageUrlField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string streamUrl
        {
            get
            {
                return this.streamUrlField;
            }
            set
            {
                this.streamUrlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string homePageUrl
        {
            get
            {
                return this.homePageUrlField;
            }
            set
            {
                this.homePageUrlField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class NewestPodcasts
    {

        private PodcastEpisode[] episodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("episode")]
        public PodcastEpisode[] episode
        {
            get
            {
                return this.episodeField;
            }
            set
            {
                this.episodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class PodcastEpisode : Child
    {

        private string streamIdField;

        private string channelIdField;

        private string descriptionField;

        private PodcastStatus statusField;

        private System.DateTime publishDateField;

        private bool publishDateFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string streamId
        {
            get
            {
                return this.streamIdField;
            }
            set
            {
                this.streamIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string channelId
        {
            get
            {
                return this.channelIdField;
            }
            set
            {
                this.channelIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public PodcastStatus status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime publishDate
        {
            get
            {
                return this.publishDateField;
            }
            set
            {
                this.publishDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool publishDateSpecified
        {
            get
            {
                return this.publishDateFieldSpecified;
            }
            set
            {
                this.publishDateFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public enum PodcastStatus
    {

        /// <remarks/>
        @new,

        /// <remarks/>
        downloading,

        /// <remarks/>
        completed,

        /// <remarks/>
        error,

        /// <remarks/>
        deleted,

        /// <remarks/>
        skipped,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Podcasts
    {

        private PodcastChannel[] channelField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("channel")]
        public PodcastChannel[] channel
        {
            get
            {
                return this.channelField;
            }
            set
            {
                this.channelField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class PodcastChannel
    {

        private PodcastEpisode[] episodeField;

        private string idField;

        private string urlField;

        private string titleField;

        private string descriptionField;

        private string coverArtField;

        private string originalImageUrlField;

        private PodcastStatus statusField;

        private string errorMessageField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("episode")]
        public PodcastEpisode[] episode
        {
            get
            {
                return this.episodeField;
            }
            set
            {
                this.episodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string coverArt
        {
            get
            {
                return this.coverArtField;
            }
            set
            {
                this.coverArtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string originalImageUrl
        {
            get
            {
                return this.originalImageUrlField;
            }
            set
            {
                this.originalImageUrlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public PodcastStatus status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string errorMessage
        {
            get
            {
                return this.errorMessageField;
            }
            set
            {
                this.errorMessageField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Lyrics
    {

        private string artistField;

        private string titleField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string artist
        {
            get
            {
                return this.artistField;
            }
            set
            {
                this.artistField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Songs
    {

        private Child[] songField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("song")]
        public Child[] song
        {
            get
            {
                return this.songField;
            }
            set
            {
                this.songField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class AlbumListID3
    {

        private AlbumID3[] albumField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("album")]
        public AlbumID3[] album
        {
            get
            {
                return this.albumField;
            }
            set
            {
                this.albumField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class AlbumList
    {

        private Child[] albumField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("album")]
        public Child[] album
        {
            get
            {
                return this.albumField;
            }
            set
            {
                this.albumField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class ChatMessages
    {

        private ChatMessage[] chatMessageField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("chatMessage")]
        public ChatMessage[] chatMessage
        {
            get
            {
                return this.chatMessageField;
            }
            set
            {
                this.chatMessageField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class ChatMessage
    {

        private string usernameField;

        private long timeField;

        private string messageField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public long time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Users
    {

        private User[] userField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("user")]
        public User[] user
        {
            get
            {
                return this.userField;
            }
            set
            {
                this.userField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class User
    {

        private int[] folderField;

        private string usernameField;

        private string emailField;

        private bool scrobblingEnabledField;

        private int maxBitRateField;

        private bool maxBitRateFieldSpecified;

        private bool adminRoleField;

        private bool settingsRoleField;

        private bool downloadRoleField;

        private bool uploadRoleField;

        private bool playlistRoleField;

        private bool coverArtRoleField;

        private bool commentRoleField;

        private bool podcastRoleField;

        private bool streamRoleField;

        private bool jukeboxRoleField;

        private bool shareRoleField;

        private bool videoConversionRoleField;

        private System.DateTime avatarLastChangedField;

        private bool avatarLastChangedFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("folder")]
        public int[] folder
        {
            get
            {
                return this.folderField;
            }
            set
            {
                this.folderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool scrobblingEnabled
        {
            get
            {
                return this.scrobblingEnabledField;
            }
            set
            {
                this.scrobblingEnabledField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int maxBitRate
        {
            get
            {
                return this.maxBitRateField;
            }
            set
            {
                this.maxBitRateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool maxBitRateSpecified
        {
            get
            {
                return this.maxBitRateFieldSpecified;
            }
            set
            {
                this.maxBitRateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool adminRole
        {
            get
            {
                return this.adminRoleField;
            }
            set
            {
                this.adminRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool settingsRole
        {
            get
            {
                return this.settingsRoleField;
            }
            set
            {
                this.settingsRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool downloadRole
        {
            get
            {
                return this.downloadRoleField;
            }
            set
            {
                this.downloadRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool uploadRole
        {
            get
            {
                return this.uploadRoleField;
            }
            set
            {
                this.uploadRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool playlistRole
        {
            get
            {
                return this.playlistRoleField;
            }
            set
            {
                this.playlistRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool coverArtRole
        {
            get
            {
                return this.coverArtRoleField;
            }
            set
            {
                this.coverArtRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool commentRole
        {
            get
            {
                return this.commentRoleField;
            }
            set
            {
                this.commentRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool podcastRole
        {
            get
            {
                return this.podcastRoleField;
            }
            set
            {
                this.podcastRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool streamRole
        {
            get
            {
                return this.streamRoleField;
            }
            set
            {
                this.streamRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool jukeboxRole
        {
            get
            {
                return this.jukeboxRoleField;
            }
            set
            {
                this.jukeboxRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool shareRole
        {
            get
            {
                return this.shareRoleField;
            }
            set
            {
                this.shareRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool videoConversionRole
        {
            get
            {
                return this.videoConversionRoleField;
            }
            set
            {
                this.videoConversionRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime avatarLastChanged
        {
            get
            {
                return this.avatarLastChangedField;
            }
            set
            {
                this.avatarLastChangedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool avatarLastChangedSpecified
        {
            get
            {
                return this.avatarLastChangedFieldSpecified;
            }
            set
            {
                this.avatarLastChangedFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class License
    {

        private bool validField;

        private string emailField;

        private System.DateTime licenseExpiresField;

        private bool licenseExpiresFieldSpecified;

        private System.DateTime trialExpiresField;

        private bool trialExpiresFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        [JsonPropertyName("valid")]
        public bool valid
        {
            get
            {
                return this.validField;
            }
            set
            {
                this.validField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        [JsonPropertyName("email")]
        public string email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime licenseExpires
        {
            get
            {
                return this.licenseExpiresField;
            }
            set
            {
                this.licenseExpiresField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool licenseExpiresSpecified
        {
            get
            {
                return this.licenseExpiresFieldSpecified;
            }
            set
            {
                this.licenseExpiresFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime trialExpires
        {
            get
            {
                return this.trialExpiresField;
            }
            set
            {
                this.trialExpiresField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool trialExpiresSpecified
        {
            get
            {
                return this.trialExpiresFieldSpecified;
            }
            set
            {
                this.trialExpiresFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(JukeboxPlaylist))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class JukeboxStatus
    {

        private int currentIndexField;

        private bool playingField;

        private float gainField;

        private int positionField;

        private bool positionFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int currentIndex
        {
            get
            {
                return this.currentIndexField;
            }
            set
            {
                this.currentIndexField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool playing
        {
            get
            {
                return this.playingField;
            }
            set
            {
                this.playingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public float gain
        {
            get
            {
                return this.gainField;
            }
            set
            {
                this.gainField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool positionSpecified
        {
            get
            {
                return this.positionFieldSpecified;
            }
            set
            {
                this.positionFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class JukeboxPlaylist : JukeboxStatus
    {

        private Child[] entryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("entry")]
        public Child[] entry
        {
            get
            {
                return this.entryField;
            }
            set
            {
                this.entryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Playlists
    {

        private Playlist[] playlistField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("playlist")]
        public Playlist[] playlist
        {
            get
            {
                return this.playlistField;
            }
            set
            {
                this.playlistField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PlaylistWithSongs))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Playlist
    {

        private string[] allowedUserField;

        private string idField;

        private string nameField;

        private string commentField;

        private string ownerField;

        private bool publicField;

        private bool publicFieldSpecified;

        private int songCountField;

        private int durationField;

        private System.DateTime createdField;

        private System.DateTime changedField;

        private string coverArtField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("allowedUser")]
        public string[] allowedUser
        {
            get
            {
                return this.allowedUserField;
            }
            set
            {
                this.allowedUserField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string owner
        {
            get
            {
                return this.ownerField;
            }
            set
            {
                this.ownerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public bool @public
        {
            get
            {
                return this.publicField;
            }
            set
            {
                this.publicField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool publicSpecified
        {
            get
            {
                return this.publicFieldSpecified;
            }
            set
            {
                this.publicFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int songCount
        {
            get
            {
                return this.songCountField;
            }
            set
            {
                this.songCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime changed
        {
            get
            {
                return this.changedField;
            }
            set
            {
                this.changedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string coverArt
        {
            get
            {
                return this.coverArtField;
            }
            set
            {
                this.coverArtField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class PlaylistWithSongs : Playlist
    {

        private Child[] entryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("entry")]
        public Child[] entry
        {
            get
            {
                return this.entryField;
            }
            set
            {
                this.entryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class SearchResult3
    {

        private ArtistID3[] artistField;

        private AlbumID3[] albumField;

        private Child[] songField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("artist")]
        public ArtistID3[] artist
        {
            get
            {
                return this.artistField;
            }
            set
            {
                this.artistField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("album")]
        public AlbumID3[] album
        {
            get
            {
                return this.albumField;
            }
            set
            {
                this.albumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("song")]
        public Child[] song
        {
            get
            {
                return this.songField;
            }
            set
            {
                this.songField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class SearchResult2
    {

        private Artist[] artistField;

        private Child[] albumField;

        private Child[] songField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("artist")]
        public Artist[] artist
        {
            get
            {
                return this.artistField;
            }
            set
            {
                this.artistField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("album")]
        public Child[] album
        {
            get
            {
                return this.albumField;
            }
            set
            {
                this.albumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("song")]
        public Child[] song
        {
            get
            {
                return this.songField;
            }
            set
            {
                this.songField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class SearchResult
    {

        private Child[] matchField;

        private int offsetField;

        private int totalHitsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("match")]
        public Child[] match
        {
            get
            {
                return this.matchField;
            }
            set
            {
                this.matchField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int offset
        {
            get
            {
                return this.offsetField;
            }
            set
            {
                this.offsetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int totalHits
        {
            get
            {
                return this.totalHitsField;
            }
            set
            {
                this.totalHitsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class NowPlaying
    {

        private NowPlayingEntry[] entryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("entry")]
        public NowPlayingEntry[] entry
        {
            get
            {
                return this.entryField;
            }
            set
            {
                this.entryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class NowPlayingEntry : Child
    {

        private string usernameField;

        private int minutesAgoField;

        private int playerIdField;

        private string playerNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int minutesAgo
        {
            get
            {
                return this.minutesAgoField;
            }
            set
            {
                this.minutesAgoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int playerId
        {
            get
            {
                return this.playerIdField;
            }
            set
            {
                this.playerIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string playerName
        {
            get
            {
                return this.playerNameField;
            }
            set
            {
                this.playerNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class VideoConversion
    {

        private string idField;

        private int bitRateField;

        private bool bitRateFieldSpecified;

        private int audioTrackIdField;

        private bool audioTrackIdFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int bitRate
        {
            get
            {
                return this.bitRateField;
            }
            set
            {
                this.bitRateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool bitRateSpecified
        {
            get
            {
                return this.bitRateFieldSpecified;
            }
            set
            {
                this.bitRateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int audioTrackId
        {
            get
            {
                return this.audioTrackIdField;
            }
            set
            {
                this.audioTrackIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool audioTrackIdSpecified
        {
            get
            {
                return this.audioTrackIdFieldSpecified;
            }
            set
            {
                this.audioTrackIdFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class AudioTrack
    {

        private string idField;

        private string nameField;

        private string languageCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string languageCode
        {
            get
            {
                return this.languageCodeField;
            }
            set
            {
                this.languageCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Captions
    {

        private string idField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class VideoInfo
    {

        private Captions[] captionsField;

        private AudioTrack[] audioTrackField;

        private VideoConversion[] conversionField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("captions")]
        public Captions[] captions
        {
            get
            {
                return this.captionsField;
            }
            set
            {
                this.captionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("audioTrack")]
        public AudioTrack[] audioTrack
        {
            get
            {
                return this.audioTrackField;
            }
            set
            {
                this.audioTrackField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("conversion")]
        public VideoConversion[] conversion
        {
            get
            {
                return this.conversionField;
            }
            set
            {
                this.conversionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Videos
    {

        private Child[] videoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("video")]
        public Child[] video
        {
            get
            {
                return this.videoField;
            }
            set
            {
                this.videoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class IndexID3
    {

        private ArtistID3[] artistField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("artist")]
        public ArtistID3[] artist
        {
            get
            {
                return this.artistField;
            }
            set
            {
                this.artistField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class ArtistsID3
    {

        private IndexID3[] indexField;

        private string ignoredArticlesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("index")]
        public IndexID3[] index
        {
            get
            {
                return this.indexField;
            }
            set
            {
                this.indexField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ignoredArticles
        {
            get
            {
                return this.ignoredArticlesField;
            }
            set
            {
                this.ignoredArticlesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Genres
    {

        private Genre[] genreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("genre")]
        public Genre[] genre
        {
            get
            {
                return this.genreField;
            }
            set
            {
                this.genreField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Genre
    {

        private int songCountField;

        private int albumCountField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int songCount
        {
            get
            {
                return this.songCountField;
            }
            set
            {
                this.songCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int albumCount
        {
            get
            {
                return this.albumCountField;
            }
            set
            {
                this.albumCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Directory
    {

        private Child[] childField;

        private string idField;

        private string parentField;

        private string nameField;

        private System.DateTime starredField;

        private bool starredFieldSpecified;

        private int userRatingField;

        private bool userRatingFieldSpecified;

        private double averageRatingField;

        private bool averageRatingFieldSpecified;

        private long playCountField;

        private bool playCountFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("child")]
        public Child[] child
        {
            get
            {
                return this.childField;
            }
            set
            {
                this.childField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string parent
        {
            get
            {
                return this.parentField;
            }
            set
            {
                this.parentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public System.DateTime starred
        {
            get
            {
                return this.starredField;
            }
            set
            {
                this.starredField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool starredSpecified
        {
            get
            {
                return this.starredFieldSpecified;
            }
            set
            {
                this.starredFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public int userRating
        {
            get
            {
                return this.userRatingField;
            }
            set
            {
                this.userRatingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool userRatingSpecified
        {
            get
            {
                return this.userRatingFieldSpecified;
            }
            set
            {
                this.userRatingFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public double averageRating
        {
            get
            {
                return this.averageRatingField;
            }
            set
            {
                this.averageRatingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool averageRatingSpecified
        {
            get
            {
                return this.averageRatingFieldSpecified;
            }
            set
            {
                this.averageRatingFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public long playCount
        {
            get
            {
                return this.playCountField;
            }
            set
            {
                this.playCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [JsonIgnore]
        public bool playCountSpecified
        {
            get
            {
                return this.playCountFieldSpecified;
            }
            set
            {
                this.playCountFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Index
    {

        private Artist[] artistField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("artist")]
        public Artist[] artist
        {
            get
            {
                return this.artistField;
            }
            set
            {
                this.artistField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class Indexes
    {

        private Artist[] shortcutField;

        private Index[] indexField;

        private Child[] childField;

        private long lastModifiedField;

        private string ignoredArticlesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("shortcut")]
        public Artist[] shortcut
        {
            get
            {
                return this.shortcutField;
            }
            set
            {
                this.shortcutField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("index")]
        public Index[] index
        {
            get
            {
                return this.indexField;
            }
            set
            {
                this.indexField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("child")]
        public Child[] child
        {
            get
            {
                return this.childField;
            }
            set
            {
                this.childField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public long lastModified
        {
            get
            {
                return this.lastModifiedField;
            }
            set
            {
                this.lastModifiedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [JsonIgnore]
        public string ignoredArticles
        {
            get
            {
                return this.ignoredArticlesField;
            }
            set
            {
                this.ignoredArticlesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class MusicFolders
    {

        private MusicFolder[] musicFolderField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("musicFolder")]
        public MusicFolder[] musicFolder
        {
            get
            {
                return this.musicFolderField;
            }
            set
            {
                this.musicFolderField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public partial class MusicFolder
    {

        private int idField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi", IncludeInSchema = false)]
    public enum ItemChoiceType
    {

        /// <remarks/>
        album,

        /// <remarks/>
        albumInfo,
        /// <remarks/>
        albumList,
        /// <remarks/>
        albumList2,

        /// <remarks/>
        artist,

        /// <remarks/>
        artistInfo,

        /// <remarks/>
        artistInfo2,

        /// <remarks/>
        artists,

        /// <remarks/>
        bookmarks,

        /// <remarks/>
        chatMessages,

        /// <remarks/>
        directory,

        /// <remarks/>
        error,

        /// <remarks/>
        genres,

        /// <remarks/>
        indexes,

        /// <remarks/>
        internetRadioStations,

        /// <remarks/>
        jukeboxPlaylist,

        /// <remarks/>
        jukeboxStatus,

        /// <remarks/>
        license,

        /// <remarks/>
        lyrics,

        /// <remarks/>
        musicFolders,

        /// <remarks/>
        newestPodcasts,

        /// <remarks/>
        nowPlaying,

        /// <remarks/>
        playQueue,

        /// <remarks/>
        playlist,

        /// <remarks/>
        playlists,

        /// <remarks/>
        podcasts,

        /// <remarks/>
        randomSongs,

        /// <remarks/>
        scanStatus,

        /// <remarks/>
        searchResult,

        /// <remarks/>
        searchResult2,

        /// <remarks/>
        searchResult3,

        /// <remarks/>
        shares,

        /// <remarks/>
        similarSongs,

        /// <remarks/>
        similarSongs2,

        /// <remarks/>
        song,

        /// <remarks/>
        songsByGenre,

        /// <remarks/>
        starred,

        /// <remarks/>
        starred2,

        /// <remarks/>
        topSongs,

        /// <remarks/>
        user,

        /// <remarks/>
        users,

        /// <remarks/>
        videoInfo,

        /// <remarks/>
        videos,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://subsonic.org/restapi")]
    public enum ResponseStatus
    {

        /// <remarks/>
        ok,

        /// <remarks/>
        failed,
    }
}
