using System.Collections.Generic;

namespace TSAPI.Public.Domain.Metadata
{
    /// <summary>Object representing a language in use within a survey</summary>
    public class Language
    {
        /// <summary>
        /// The unique Id that is used to refer to a language within the survey metadata and interview data. Although there is no restriction on language id, the intended values of this attribute are described in the official W3C XML version 1.0
        /// specification as:- "The values of the attribute are language identifiers as defined by IETF (Internet Engineering Task Force) RFC 3066, "Tags for the Identification of
        /// Languages"(http://www.ietf.org/rfc/rfc3066.txt) or its successor on the Standards Track." 
        ///</summary>
        public string LanguageId { get; set; }
        /// <summary>The human readable name used to refer to a language</summary>
        public string Name { get; set; }
        /// <summary>List of sub-languages (if any) that are grouped within the parent language (e.g. English => en-GB, en-US)</summary>
        public List<Language> SubLanguages { get; set; }
    }
}
