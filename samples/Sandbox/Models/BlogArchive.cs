using PiranhaCMSTest.Models.Regions;
using Piranha.AttributeBuilder;
using Piranha.Models;
using Piranha.Extend;

namespace PiranhaCMSTest.Models
{
    [PageType(Title = "Blog archive", UseBlocks = false)]
    public class BlogArchive  : ArchivePage<BlogArchive>
    {
        /// <summary>
        /// Gets/sets the archive hero.
        /// </summary>
        [Region(Display = RegionDisplayMode.Setting)]
        public Hero Hero { get; set; }
    }
}