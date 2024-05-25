using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDReport
{
    public class next_session_data_object
    {
        public class Rootobject
        {
            public Data data { get; set; }
        }

        public class Data
        {
            public Cix_Nfx_Actions_Execute cix_nfx_actions_execute { get; set; }
        }

        public class Cix_Nfx_Actions_Execute
        {
            public Screen screen { get; set; }
            public Curation_Flow curation_flow { get; set; }
        }

        public class Screen
        {
            public View_Model view_model { get; set; }
        }

        public class View_Model
        {
            public string __typename { get; set; }
            public string __isCIXScreenViewModel { get; set; }
            public string serialized_state { get; set; }
            public string context { get; set; }
            public Header header { get; set; }
            public Title title { get; set; }
            public object subtag_title { get; set; }
            public object subtag_subtitle { get; set; }
            public object subtitle_learn_more_link_text { get; set; }
            public object subtitle_learn_more_link { get; set; }
            public bool allow_question_tree { get; set; }
            public Subtitle subtitle { get; set; }
            public object[] persistent_units { get; set; }
            public Tag[] tags { get; set; }
            public object[] actions { get; set; }
            public bool is_tag_search_enabled { get; set; }
            public object selected_tag { get; set; }
            public bool is_reported { get; set; }
            public string reported_id { get; set; }
            public string report_entrypoint_action { get; set; }
            public __Module_Operation_Cixfacebookscreensrenderer_Screen __module_operation_CIXFacebookScreensRenderer_screen { get; set; }
            public __Module_Component_Cixfacebookscreensrenderer_Screen __module_component_CIXFacebookScreensRenderer_screen { get; set; }
        }

        public class Header
        {
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
            public string text { get; set; }
        }

        public class Title
        {
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
            public string text { get; set; }
        }

        public class Subtitle
        {
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
            public string text { get; set; }
        }

        public class __Module_Operation_Cixfacebookscreensrenderer_Screen
        {
            public string __dr { get; set; }
        }

        public class __Module_Component_Cixfacebookscreensrenderer_Screen
        {
            public string __dr { get; set; }
        }

        public class Tag
        {
            public string type { get; set; }
            public Followup followup { get; set; }
            public Title4 title { get; set; }
            public object uri { get; set; }
        }

        public class Followup
        {
            public Tag1[] tags { get; set; }
            public Title1 title { get; set; }
        }

        public class Title1
        {
            public string text { get; set; }
        }

        public class Tag1
        {
            public string type { get; set; }
            public Followup1 followup { get; set; }
            public Title3 title { get; set; }
            public object uri { get; set; }
            public string __typename { get; set; }
        }

        public class Followup1
        {
            public object[] tags { get; set; }
            public Title2 title { get; set; }
        }

        public class Title2
        {
            public string text { get; set; }
        }

        public class Title3
        {
            public string text { get; set; }
        }

        public class Title4
        {
            public string text { get; set; }
        }

        public class Curation_Flow
        {
            public Executed_Action executed_action { get; set; }
            public string action_path { get; set; }
            public Affirmation_Text affirmation_text { get; set; }
            public Feedback_Text feedback_text { get; set; }
            public bool undoable { get; set; }
            public Followup_Actions[] followup_actions { get; set; }
            public object support_action { get; set; }
        }

        public class Executed_Action
        {
            public string __typename { get; set; }
            public string context { get; set; }
            public string type { get; set; }
            public object unique_label { get; set; }
            public Icon icon { get; set; }
            public string id { get; set; }
        }

        public class Icon
        {
            public int height { get; set; }
            public int scale { get; set; }
            public string uri { get; set; }
            public int width { get; set; }
        }

        public class Affirmation_Text
        {
            public string text { get; set; }
        }

        public class Feedback_Text
        {
            public string text { get; set; }
        }

        public class Followup_Actions
        {
            public string __typename { get; set; }
            public string __isNFXAction { get; set; }
            public string id { get; set; }
            public string type { get; set; }
            public string context { get; set; }
            public bool can_display_completed_state { get; set; }
            public bool already_completed { get; set; }
            public Title5 title { get; set; }
            public Subtitle1 subtitle { get; set; }
            public Icon1 icon { get; set; }
            public bool confirmation_required { get; set; }
            public string confirmation_type { get; set; }
            public Loading_Text loading_text { get; set; }
            public object confirmation_message { get; set; }
            public Confirmation_Button_Label confirmation_button_label { get; set; }
            public string target_user_id { get; set; }
            public Confirmed_Icon confirmed_icon { get; set; }
            public Confirmed_Title confirmed_title { get; set; }
            public Confirmed_Subtitle confirmed_subtitle { get; set; }
            public bool can_undo { get; set; }
            public Undo_Button_Label undo_button_label { get; set; }
            public string redirect_uri { get; set; }
            public string redirect_style { get; set; }
            public bool is_disabled { get; set; }
            public object tooltip { get; set; }
        }

        public class Title5
        {
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
            public string text { get; set; }
        }

        public class Subtitle1
        {
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
            public string text { get; set; }
        }

        public class Icon1
        {
            public int height { get; set; }
            public int scale { get; set; }
            public string uri { get; set; }
            public int width { get; set; }
        }

        public class Loading_Text
        {
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
            public string text { get; set; }
        }

        public class Confirmation_Button_Label
        {
            public string text { get; set; }
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
        }

        public class Confirmed_Icon
        {
            public int height { get; set; }
            public int scale { get; set; }
            public string uri { get; set; }
            public int width { get; set; }
        }

        public class Confirmed_Title
        {
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
            public string text { get; set; }
        }

        public class Confirmed_Subtitle
        {
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
            public string text { get; set; }
        }

        public class Undo_Button_Label
        {
            public string text { get; set; }
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
        }
    }

    public class next_session_context_object
    {
        public class Rootobject
        {
            public string session_id { get; set; }
            public string support_type { get; set; }
            public int type { get; set; }
            public string story_location { get; set; }
            public string tracking { get; set; }
            public string entry_point { get; set; }
            public string reporting_ufo_key { get; set; }
            public string actions_taken { get; set; }
            public Additional_Data additional_data { get; set; }
            public string screen_type { get; set; }
            public string hideable_token { get; set; }
            public string story_permalink_token { get; set; }
        }

        public class Additional_Data
        {
            public string frx_validation_ent { get; set; }
            public bool is_ixt_session { get; set; }
            public bool is_ixt_session_logged { get; set; }
        }
    }
}
