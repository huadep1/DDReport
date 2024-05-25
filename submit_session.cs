using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDReport
{
    public class submit_session_data_object
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
            public Tag[] tags { get; set; }
            public bool allow_question_tree { get; set; }
            public Previous_Step previous_step { get; set; }
            public Current_Step current_step { get; set; }
            public Next_Step next_step { get; set; }
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

        public class Previous_Step
        {
            public Title1 title { get; set; }
            public Description description { get; set; }
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

        public class Current_Step
        {
            public Title2 title { get; set; }
            public Description1 description { get; set; }
        }

        public class Title2
        {
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
            public string text { get; set; }
        }

        public class Description1
        {
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
            public string text { get; set; }
        }

        public class Next_Step
        {
            public Title3 title { get; set; }
            public Description2 description { get; set; }
        }

        public class Title3
        {
            public object[] delight_ranges { get; set; }
            public object[] image_ranges { get; set; }
            public object[] inline_style_ranges { get; set; }
            public object[] aggregated_ranges { get; set; }
            public object[] ranges { get; set; }
            public object[] color_ranges { get; set; }
            public string text { get; set; }
        }

        public class Description2
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
            public Title4 title { get; set; }
        }

        public class Title4
        {
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
}
