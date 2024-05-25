﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDReport
{
    public class execute_session_data_object
    {
        public class Rootobject
        {
            public Data data { get; set; }
        }

        public class Data
        {
            public Ixt_Screen_Next ixt_screen_next { get; set; }
        }

        public class Ixt_Screen_Next
        {
            public View_Model view_model { get; set; }
            public string display_type { get; set; }
        }

        public class View_Model
        {
            public string __typename { get; set; }
            public string serialized_state { get; set; }
            public string __isCIXScreenViewModel { get; set; }
            public string context { get; set; }
            public Title title { get; set; }
            public Heading heading { get; set; }
            public Description description { get; set; }
            public object additional_details { get; set; }
            public Policy[] policies { get; set; }
            public object[] additional_policies { get; set; }
            public object learn_more_label { get; set; }
            public object learn_more_uri { get; set; }
            public Button[] buttons { get; set; }
            public __Module_Operation_Cixfacebookscreensrenderer_Screen __module_operation_CIXFacebookScreensRenderer_screen { get; set; }
            public __Module_Component_Cixfacebookscreensrenderer_Screen __module_component_CIXFacebookScreensRenderer_screen { get; set; }
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

        public class Heading
        {
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
            public string text { get; set; }
        }

        public class Description
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

        public class Policy
        {
            public Title1 title { get; set; }
            public object subtitle { get; set; }
        }

        public class Title1
        {
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
            public string text { get; set; }
        }

        public class Button
        {
            public string action_type { get; set; }
            public string button_type { get; set; }
            public Label label { get; set; }
            public string uri { get; set; }
        }

        public class Label
        {
            public string text { get; set; }
        }
    }

    public class execute_session_context_object
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
            public string frx_report_action { get; set; }
            public string[] rapid_reporting_tags { get; set; }
            public bool frx_feedback_submitted { get; set; }
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
            public object checked_component_names { get; set; }
        }
    }
}
