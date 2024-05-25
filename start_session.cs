using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDReport
{
    public class start_session_data_object
    {
        public class Rootobject
        {
            public Data data { get; set; }
        }

        public class Data
        {
            public Feed_Unit feed_unit { get; set; }
        }

        public class Feed_Unit
        {
            public string __typename { get; set; }
            public string __isFeedUnitWithNFXActions { get; set; }
            public Nfx_Action_Menu_Items[] nfx_action_menu_items { get; set; }
            public string __isNode { get; set; }
            public string id { get; set; }
        }

        public class Nfx_Action_Menu_Items
        {
            public string __typename { get; set; }
            public string __isStoryMenuItem { get; set; }
            public string __isNFXActionMenuItem { get; set; }
            public Save_Info save_info { get; set; }
            public Story story { get; set; }
            public __Module_Operation_Cometfeedstorymenuwithoutexpandables_Story __module_operation_CometFeedStoryMenuWithoutExpandables_story { get; set; }
            public __Module_Component_Cometfeedstorymenuwithoutexpandables_Story __module_component_CometFeedStoryMenuWithoutExpandables_story { get; set; }
            public bool has_feed_reminders { get; set; }
            public Feed_Unit1 feed_unit { get; set; }
            public Action action { get; set; }
            public object legal_reporting_cta_type { get; set; }
            public object legal_reporting_uri { get; set; }
        }

        public class Save_Info
        {
            public string story_save_type { get; set; }
        }

        public class Story
        {
            public string id { get; set; }
            public Save_Info1 save_info { get; set; }
            public Feedback feedback { get; set; }
            public Attachment[] attachments { get; set; }
        }

        public class Save_Info1
        {
            public string viewer_save_state { get; set; }
            public Save_Flow save_flow { get; set; }
        }

        public class Save_Flow
        {
            public string __typename { get; set; }
            public Collection_Candidates collection_candidates { get; set; }
        }

        public class Collection_Candidates
        {
            public Top_Collections[] top_collections { get; set; }
            public string bottom_sheet_type { get; set; }
            public string preselected { get; set; }
        }

        public class Top_Collections
        {
            public string __typename { get; set; }
            public string __isContentCollection { get; set; }
            public string id { get; set; }
            public string collection_title { get; set; }
            public object collection_thumbnail_image { get; set; }
            public object privacy_scope { get; set; }
        }

        public class Feedback
        {
            public string id { get; set; }
            public bool is_viewer_subscribed { get; set; }
        }

        public class Attachment
        {
            public Media media { get; set; }
        }

        public class Media
        {
            public string __typename { get; set; }
            public string __isNode { get; set; }
            public string id { get; set; }
        }

        public class __Module_Operation_Cometfeedstorymenuwithoutexpandables_Story
        {
            public string __dr { get; set; }
        }

        public class __Module_Component_Cometfeedstorymenuwithoutexpandables_Story
        {
            public string __dr { get; set; }
        }

        public class Feed_Unit1
        {
            public string __typename { get; set; }
            public string __isNode { get; set; }
            public string id { get; set; }
        }

        public class Action
        {
            public string __typename { get; set; }
            public string context { get; set; }
            public string type { get; set; }
            public Title title { get; set; }
            public Subtitle subtitle { get; set; }
            public Icon icon { get; set; }
            public bool can_start_curation_flow { get; set; }
            public string id { get; set; }
        }

        public class Title
        {
            public string text { get; set; }
        }

        public class Subtitle
        {
            public string text { get; set; }
        }

        public class Icon
        {
            public int height { get; set; }
            public int scale { get; set; }
            public string uri { get; set; }
            public int width { get; set; }
        }
    }

    public class start_session_context_object
    {
        public class RootObject
        {
            public string session_id { get; set; }
            public string support_type { get; set; }
            public int type { get; set; }
            public string story_location { get; set; }
            public string tracking { get; set; }
            public string entry_point { get; set; }
            public string reporting_ufo_key { get; set; }
            public Additional_Data additional_data { get; set; }
            public string hideable_token { get; set; }
            public string story_permalink_token { get; set; }
        }

        public class Additional_Data
        {
            public string frx_validation_ent { get; set; }
        }
    }
}
