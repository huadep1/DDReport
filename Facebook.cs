using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace DDReport
{
    internal class Facebook
    {
        private CookieContainer cookies;
        private string storyid;
        private string dtsg;
        private string session_id;
        private string tracking;
        private string reporting_ufo_key;
        private string hideable_token;
        private string story_permalink_token;
        private string actor_id;
        private string serialized_state;
        private HttpClient client;
        private string tags_string;

        public Facebook(string cookies, string post_url)
        {
            this.cookies = parser_cookies(cookies);
            client = new HttpClient(new HttpClientHandler() { CookieContainer = this.cookies });
            actor_id = cookies.Split("c_user=")[1].Split(";")[0];
            storyid = get_story_id(post_url).Result;
            dtsg = get_dtsg_token().Result;
        }

        private CookieContainer parser_cookies(string cookies)
        {
            CookieContainer cookieContainer = new CookieContainer();
            string[] cookieValues = cookies.Split(';');
            foreach (string item in cookieValues)
            {
                var temp1 = item.Trim();
                var temp2 = temp1.Split('=');
                if (temp2.Length > 1)
                {
                    cookieContainer.Add(
                        new Uri("https://www.facebook.com"),
                        new Cookie(temp2[0], temp2[1])
                    );
                }
            }
            return cookieContainer;
        }

        private async Task<string> get_dtsg_token()
        {
            using HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Get,
                "https://www.facebook.com/help/contact/227993721031586?ref=cr"
            );
            request.Headers.Add("authority", "www.facebook.com");
            request.Headers.Add(
                "accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
            );
            request.Headers.Add("accept-language", "en-US,en;q=0.9,vi;q=0.8");
            request.Headers.Add("dpr", "1");
            request.Headers.Add("sec-ch-prefers-color-scheme", "dark");
            request.Headers.Add(
                "sec-ch-ua",
                "\"Not/A)Brand\";v=\"99\", \"Google Chrome\";v=\"115\", \"Chromium\";v=\"115\""
            );
            request.Headers.Add(
                "sec-ch-ua-full-version-list",
                "\"Not/A)Brand\";v=\"99.0.0.0\", \"Google Chrome\";v=\"115.0.5790.171\", \"Chromium\";v=\"115.0.5790.171\""
            );
            request.Headers.Add("sec-ch-ua-mobile", "?0");
            request.Headers.Add("sec-ch-ua-model", "\"\"");
            request.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
            request.Headers.Add("sec-ch-ua-platform-version", "\"10.0.0\"");
            request.Headers.Add("sec-fetch-dest", "document");
            request.Headers.Add("sec-fetch-mode", "navigate");
            request.Headers.Add("sec-fetch-site", "same-origin");
            request.Headers.Add("sec-fetch-user", "?1");
            request.Headers.Add("upgrade-insecure-requests", "1");
            request.Headers.Add(
                "user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36"
            );
            request.Headers.Add("viewport-width", "752");
            try
            {
                using HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string response_text = await response.Content.ReadAsStringAsync();
                return extra_get_dtsg_token(response_text);
            }
            catch
            {
                return "";
            }
        }

        private string extra_get_dtsg_token(string response_text)
        {
            try
            {
                var result = new Regex("name=\"fb_dtsg\" value=\"([^\"]+)\"", RegexOptions.None)
                    .Match(response_text)
                    .Groups[1].Value;
                return result;
            }
            catch
            {
                return "";
            }
        }

        private async Task<string> get_story_id(string post_url)
        {
            using HttpClient client = new HttpClient();
            using HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                "https://www.facebook.com/ajax/bulk-route-definitions/"
            );
            request.Headers.Add("authority", "www.facebook.com");
            request.Headers.Add(
                "accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
            );
            request.Headers.Add("accept-language", "en-US,en;q=0.9,vi;q=0.8");
            request.Headers.Add("dpr", "1");
            request.Headers.Add("sec-ch-prefers-color-scheme", "dark");
            request.Headers.Add(
                "sec-ch-ua",
                "\"Not/A)Brand\";v=\"99\", \"Google Chrome\";v=\"115\", \"Chromium\";v=\"115\""
            );
            request.Headers.Add(
                "sec-ch-ua-full-version-list",
                "\"Not/A)Brand\";v=\"99.0.0.0\", \"Google Chrome\";v=\"115.0.5790.171\", \"Chromium\";v=\"115.0.5790.171\""
            );
            request.Headers.Add("sec-ch-ua-mobile", "?0");
            request.Headers.Add("sec-ch-ua-model", "\"\"");
            request.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
            request.Headers.Add("sec-ch-ua-platform-version", "\"10.0.0\"");
            request.Headers.Add("sec-fetch-dest", "document");
            request.Headers.Add("sec-fetch-mode", "navigate");
            request.Headers.Add("sec-fetch-site", "same-origin");
            request.Headers.Add("sec-fetch-user", "?1");
            request.Headers.Add("upgrade-insecure-requests", "1");
            request.Headers.Add(
                "user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36"
            );
            request.Headers.Add("x-fb-lsd", "AVpnruPa-h0");
            var data = new Dictionary<string, string>()
            {
                { "__a", "1" },
                { "__aaid", "0" },
                { "__ccg", "EXCELLENT" },
                { "__comet_req", "15" },
                { "__req", "1" },
                { "__rev", "1012422039" },
                { "__spin_b", "trunk" },
                { "__spin_r", "1012422039" },
                { "__spin_t", "1711750609" },
                { "__user", "0" },
                { "dpr", "1" },
                { "jazoest", "2978" },
                { "lsd", "AVpnruPa-h0" },
                { "route_urls[0]", post_url },
                { "routing_namespace", "fb_comet" },
            };
            request.Content = new FormUrlEncodedContent(data);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(
                "application/x-www-form-urlencoded"
            );
            try
            {
                using HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string response_text = await response.Content.ReadAsStringAsync();
                return extra_get_story_id(response_text);
            }
            catch
            {
                return "";
            }
        }

        private string extra_get_story_id(string response_text)
        {
            try
            {
                var result = new Regex("\"storyID\":\"([^\\\"]+)\"", RegexOptions.None)
                    .Match(response_text)
                    .Groups[1].Value;
                return result;
            }
            catch
            {
                return "";
            }
        }

        public async Task start_session()
        {
            using HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                "https://www.facebook.com/api/graphql/"
            );
            request.Headers.Add("authority", "www.facebook.com");
            request.Headers.Add(
                "accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
            );
            request.Headers.Add("accept-language", "en-US,en;q=0.9,vi;q=0.8");
            request.Headers.Add("dpr", "1");
            request.Headers.Add("sec-ch-prefers-color-scheme", "dark");
            request.Headers.Add(
                "sec-ch-ua",
                "\"Not/A)Brand\";v=\"99\", \"Google Chrome\";v=\"115\", \"Chromium\";v=\"115\""
            );
            request.Headers.Add(
                "sec-ch-ua-full-version-list",
                "\"Not/A)Brand\";v=\"99.0.0.0\", \"Google Chrome\";v=\"115.0.5790.171\", \"Chromium\";v=\"115.0.5790.171\""
            );
            request.Headers.Add("sec-ch-ua-mobile", "?0");
            request.Headers.Add("sec-ch-ua-model", "\"\"");
            request.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
            request.Headers.Add("sec-ch-ua-platform-version", "\"10.0.0\"");
            request.Headers.Add("sec-fetch-dest", "document");
            request.Headers.Add("sec-fetch-mode", "navigate");
            request.Headers.Add("sec-fetch-site", "same-origin");
            request.Headers.Add("sec-fetch-user", "?1");
            request.Headers.Add("upgrade-insecure-requests", "1");
            request.Headers.Add(
                "user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36"
            );
            request.Headers.Add("x-fb-lsd", "AVpnruPa-h0");
            var data = new Dictionary<string, string>()
            {
                { "__aaid", "0" },
                { "__a", "1" },
                { "__req", "1c" },
                { "dpr", "1" },
                { "__comet_req", "15" },
                { "fb_dtsg", dtsg },
                { "fb_api_caller_class", "RelayModern" },
                { "fb_api_req_friendly_name", "CometFeedStoryMenuQuery" },
                {
                    "variables",
                    "{\"feed_location\":\"PERMALINK\",\"id\":\""
                        + storyid
                        + "\",\"scale\":1,\"serialized_frtp_identifiers\":null,\"story_debug_info\":null,\"__relay_internal__pv__VideoPlayerRelayReplaceDashManifestWithPlaylistrelayprovider\":true}"
                },
                { "doc_id", "6771805742920429" }
            };
            request.Content = new FormUrlEncodedContent(data);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(
                "application/x-www-form-urlencoded"
            );
            try
            {
                using HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string response_text = await response.Content.ReadAsStringAsync();
                await extra_start_session(response_text);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }

        private async Task extra_start_session(string response_text)
        {
            try
            {
                var response_json =
                    JsonConvert.DeserializeObject<start_session_data_object.Rootobject>(
                        response_text
                    );
                var context_data = response_json.data.feed_unit.nfx_action_menu_items
                    .Last()
                    .action.context;
                var context =
                    JsonConvert.DeserializeObject<start_session_context_object.RootObject>(
                        context_data
                    );
                session_id = context.session_id;
                tracking = context.tracking;
                reporting_ufo_key = context.reporting_ufo_key;
                hideable_token = context.hideable_token;
                story_permalink_token = context.story_permalink_token;
                await next_session();
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }

        private async Task next_session()
        {
            using HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                "https://www.facebook.com/api/graphql/"
            );
            request.Headers.Add("authority", "www.facebook.com");
            request.Headers.Add(
                "accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
            );
            request.Headers.Add("accept-language", "en-US,en;q=0.9,vi;q=0.8");
            request.Headers.Add("dpr", "1");
            request.Headers.Add("sec-ch-prefers-color-scheme", "dark");
            request.Headers.Add(
                "sec-ch-ua",
                "\"Not/A)Brand\";v=\"99\", \"Google Chrome\";v=\"115\", \"Chromium\";v=\"115\""
            );
            request.Headers.Add(
                "sec-ch-ua-full-version-list",
                "\"Not/A)Brand\";v=\"99.0.0.0\", \"Google Chrome\";v=\"115.0.5790.171\", \"Chromium\";v=\"115.0.5790.171\""
            );
            request.Headers.Add("sec-ch-ua-mobile", "?0");
            request.Headers.Add("sec-ch-ua-model", "\"\"");
            request.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
            request.Headers.Add("sec-ch-ua-platform-version", "\"10.0.0\"");
            request.Headers.Add("sec-fetch-dest", "document");
            request.Headers.Add("sec-fetch-mode", "navigate");
            request.Headers.Add("sec-fetch-site", "same-origin");
            request.Headers.Add("sec-fetch-user", "?1");
            request.Headers.Add("upgrade-insecure-requests", "1");
            request.Headers.Add(
                "user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36"
            );
            request.Headers.Add("x-fb-lsd", "AVpnruPa-h0");
            var data = new Dictionary<string, string>()
            {
                { "__aaid", "0" },
                { "__a", "1" },
                { "__req", "1c" },
                { "dpr", "1" },
                { "__comet_req", "15" },
                { "fb_dtsg", dtsg },
                { "fb_api_caller_class", "RelayModern" },
                { "fb_api_req_friendly_name", "CometFeedStoryMenuQuery" },
                {
                    "variables",
                    "{\"input\":{\"context\":\"{\\\"session_id\\\":\\\""
                        + session_id
                        + "\\\",\\\"support_type\\\":\\\"chevron\\\",\\\"type\\\":4,\\\"story_location\\\":\\\"permalink\\\",\\\"tracking\\\":\\\""
                        + tracking
                        + "\\\",\\\"entry_point\\\":\\\"chevron_button\\\",\\\"reporting_ufo_key\\\":\\\""
                        + reporting_ufo_key
                        + "\\\",\\\"additional_data\\\":{\\\"frx_validation_ent\\\":\\\"IEntPost\\\"},\\\"hideable_token\\\":\\\""
                        + hideable_token
                        + "\\\",\\\"story_permalink_token\\\":\\\""
                        + story_permalink_token
                        + "\\\"}\",\"type\":\"CHEVRON_FEEDBACK_ENTRYPOINT\",\"actor_id\":\""
                        + actor_id
                        + "\",\"client_mutation_id\":\"2\"},\"scale\":1,\"__relay_internal__pv__VideoPlayerRelayReplaceDashManifestWithPlaylistrelayprovider\":true}"
                },
                { "doc_id", "7864506440228225" }
            };
            request.Content = new FormUrlEncodedContent(data);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(
                "application/x-www-form-urlencoded"
            );
            try
            {
                using HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string response_text = await response.Content.ReadAsStringAsync();
                await extra_next_session(response_text);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }

        private async Task extra_next_session(string response_text)
        {
            try
            {
                var response_json =
                    JsonConvert.DeserializeObject<next_session_data_object.Rootobject>(
                        response_text
                    );
                var context_data = response_json
                    .data
                    .cix_nfx_actions_execute
                    .screen
                    .view_model
                    .context;
                var context = JsonConvert.DeserializeObject<next_session_context_object.Rootobject>(
                    context_data
                );
                session_id = context.session_id;
                tracking = context.tracking;
                reporting_ufo_key = context.reporting_ufo_key;
                hideable_token = context.hideable_token;
                story_permalink_token = context.story_permalink_token;
                serialized_state = response_json
                    .data
                    .cix_nfx_actions_execute
                    .screen
                    .view_model
                    .serialized_state;
                await execute_session();
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }

        private async Task execute_session()
        {
            var rand = new Random();
            var tags = new List<string>()
            {
                "[\"NUDITY\",\"NUDITY_ADULT_NUDITY\"]",
                "[\"NUDITY\",\"NUDITY_SEXUALLY_SUGGESTIVE\"]",
                "[\"NUDITY\",\"NUDITY_SEXUAL_ACTIVITY\"]",
                "[\"NUDITY\",\"NUDITY_SEXUAL_EXPLOITATION\"]",
                "[\"NUDITY\",\"NUDITY_SEXUAL_SERVICES\"]",
                "[\"NUDITY\",\"NUDITY_INVOLVES_A_CHILD\"]",
                "[\"NUDITY\",\"NUDITY_SHARING_PRIVATE_IMAGES\"]",
                "[\"VIOLENCE\",\"GRAPHIC_VIOLENCE\"]",
                "[\"VIOLENCE\",\"DEATH_OR_SEVERE_INJURY\"]",
                "[\"VIOLENCE\",\"VIOLENT_THREAT\"]",
                "[\"VIOLENCE\",\"ANIMAL_ABUSE\"]",
                "[\"VIOLENCE\",\"SEXUAL_VIOLENCE\"]",
                "[\"VIOLENCE\",\"VIOLENCE_SOMETHING_ELSE\"]",
                "[\"HARASSMENT\",\"HARASSMENT_ME\"]",
                "[\"SUICIDE\"]",
                "[\"FALSE_NEWS\",\"MISINFORMATION_HEALTH\"]",
                "[\"FALSE_NEWS\",\"MISINFORMATION_POLITICS\"]",
                "[\"FALSE_NEWS\",\"MISINFORMATION_SOCIAL_ISSUE\"]",
                "[\"FALSE_NEWS\",\"MISINFORMATION_SOMETHING_ELSE\"]",
                "[\"SPAM\"]",
                "[\"DRUGS\",\"HIGH_RISK_DRUGS\"]",
                "[\"DRUGS\",\"OTHER_DRUGS\"]",
                "[\"UNAUTHORIZED_SALES\",\"UNAUTHORIZED_DRUGS_SALES\"]",
                "[\"UNAUTHORIZED_SALES\",\"UNAUTHORIZED_WEAPONS_SALES\"]",
                "[\"UNAUTHORIZED_SALES\",\"ENDANGERED_ANIMALS\"]",
                "[\"UNAUTHORIZED_SALES\",\"OTHER_ANIMALS\"]",
                "[\"UNAUTHORIZED_SALES\",\"UNAUTHORIZED_SALES_SOMETHING_ELSE\"",
                "[\"HATE_SPEECH\",\"HATE_SPEECH_RACE_OR_ETHNICITY\"]",
                "[\"HATE_SPEECH\",\"HATE_SPEECH_NATIONAL_ORIGIN\"]",
                "[\"HATE_SPEECH\",\"HATE_SPEECH_RELIGIOUS_AFFILIATION\"]",
                "[\"HATE_SPEECH\",\"HATE_SPEECH_SOCIAL_CASTE\"]",
                "[\"HATE_SPEECH\",\"HATE_SPEECH_SEXUAL_ORIENTATION\"]",
                "[\"HATE_SPEECH\",\"HATE_SPEECH_SEX_OR_GENDER_IDENTITY\"]",
                "[\"HATE_SPEECH\",\"HATE_SPEECH_DISABILITY_OR_DISEASE\"]",
                "[\"HATE_SPEECH\",\"HATE_SPEECH_SOMETHING_ELSE\"]",
                "[\"EATING_DISORDER\"]",
                "[\"INVOLVES_A_CHILD\",\"NUDITY_INVOLVES_A_CHILD\"]",
                "[\"INVOLVES_A_CHILD\",\"CHILD_ABUSE\"]",
                "[\"TERRORISM\"]",
            };
            tags_string = tags[rand.Next(tags.Count)];
            using HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                "https://www.facebook.com/api/graphql/"
            );
            request.Headers.Add("authority", "www.facebook.com");
            request.Headers.Add(
                "accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
            );
            request.Headers.Add("accept-language", "en-US,en;q=0.9,vi;q=0.8");
            request.Headers.Add("dpr", "1");
            request.Headers.Add("sec-ch-prefers-color-scheme", "dark");
            request.Headers.Add(
                "sec-ch-ua",
                "\"Not/A)Brand\";v=\"99\", \"Google Chrome\";v=\"115\", \"Chromium\";v=\"115\""
            );
            request.Headers.Add(
                "sec-ch-ua-full-version-list",
                "\"Not/A)Brand\";v=\"99.0.0.0\", \"Google Chrome\";v=\"115.0.5790.171\", \"Chromium\";v=\"115.0.5790.171\""
            );
            request.Headers.Add("sec-ch-ua-mobile", "?0");
            request.Headers.Add("sec-ch-ua-model", "\"\"");
            request.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
            request.Headers.Add("sec-ch-ua-platform-version", "\"10.0.0\"");
            request.Headers.Add("sec-fetch-dest", "document");
            request.Headers.Add("sec-fetch-mode", "navigate");
            request.Headers.Add("sec-fetch-site", "same-origin");
            request.Headers.Add("sec-fetch-user", "?1");
            request.Headers.Add("upgrade-insecure-requests", "1");
            request.Headers.Add(
                "user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36"
            );
            request.Headers.Add("x-fb-lsd", "AVpnruPa-h0");
            var data = new Dictionary<string, string>()
            {
                { "__aaid", "0" },
                { "__a", "1" },
                { "__req", "1c" },
                { "dpr", "1" },
                { "__comet_req", "15" },
                { "fb_dtsg", dtsg },
                { "fb_api_caller_class", "RelayModern" },
                { "fb_api_req_friendly_name", "CometFeedStoryMenuQuery" },
                {
                    "variables",
                    "{\"input\":{\"frx_tag_selection_screen\":{\"context\":\"{\\\"session_id\\\":\\\""
                        + session_id
                        + "\\\",\\\"support_type\\\":\\\"frx\\\",\\\"type\\\":4,\\\"story_location\\\":\\\"permalink\\\",\\\"tracking\\\":\\\""
                        + tracking
                        + "\\\",\\\"entry_point\\\":\\\"chevron_button\\\",\\\"reporting_ufo_key\\\":\\\""
                        + reporting_ufo_key
                        + "\\\",\\\"additional_data\\\":{\\\"frx_validation_ent\\\":\\\"IEntPost\\\",\\\"is_ixt_session\\\":true,\\\"is_ixt_session_logged\\\":true},\\\"screen_type\\\":\\\"frx_tag_selection_screen\\\",\\\"hideable_token\\\":\\\""
                        + hideable_token
                        + "\\\",\\\"story_permalink_token\\\":\\\""
                        + story_permalink_token
                        + "\\\"}\",\"serialized_state\":\""
                        + serialized_state
                        + "\",\"show_tag_search\":false,\"tags\":"
                        + tags_string
                        + "},\"actor_id\":\""
                        + actor_id
                        + "\",\"client_mutation_id\":\"4\"},\"scale\":1,\"__relay_internal__pv__VideoPlayerRelayReplaceDashManifestWithPlaylistrelayprovider\":true}"
                },
                { "doc_id", "7355939297820143" }
            };
            request.Content = new FormUrlEncodedContent(data);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(
                "application/x-www-form-urlencoded"
            );
            try
            {
                using HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string response_text = await response.Content.ReadAsStringAsync();
                await extra_execute_session(response_text);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }

        private async Task extra_execute_session(string response_text)
        {
            try
            {
                var response_json =
                    JsonConvert.DeserializeObject<execute_session_data_object.Rootobject>(
                        response_text
                    );
                var context_data = response_json.data.ixt_screen_next.view_model.context;
                var context =
                    JsonConvert.DeserializeObject<execute_session_context_object.Rootobject>(
                        context_data
                    );
                session_id = context.session_id;
                tracking = context.tracking;
                reporting_ufo_key = context.reporting_ufo_key;
                hideable_token = context.hideable_token;
                story_permalink_token = context.story_permalink_token;
                serialized_state = response_json.data.ixt_screen_next.view_model.serialized_state;
                await submit_session();
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }

        private async Task submit_session()
        {
            using HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                "https://www.facebook.com/api/graphql/"
            );
            request.Headers.Add("authority", "www.facebook.com");
            request.Headers.Add(
                "accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
            );
            request.Headers.Add("accept-language", "en-US,en;q=0.9,vi;q=0.8");
            request.Headers.Add("dpr", "1");
            request.Headers.Add("sec-ch-prefers-color-scheme", "dark");
            request.Headers.Add(
                "sec-ch-ua",
                "\"Not/A)Brand\";v=\"99\", \"Google Chrome\";v=\"115\", \"Chromium\";v=\"115\""
            );
            request.Headers.Add(
                "sec-ch-ua-full-version-list",
                "\"Not/A)Brand\";v=\"99.0.0.0\", \"Google Chrome\";v=\"115.0.5790.171\", \"Chromium\";v=\"115.0.5790.171\""
            );
            request.Headers.Add("sec-ch-ua-mobile", "?0");
            request.Headers.Add("sec-ch-ua-model", "\"\"");
            request.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
            request.Headers.Add("sec-ch-ua-platform-version", "\"10.0.0\"");
            request.Headers.Add("sec-fetch-dest", "document");
            request.Headers.Add("sec-fetch-mode", "navigate");
            request.Headers.Add("sec-fetch-site", "same-origin");
            request.Headers.Add("sec-fetch-user", "?1");
            request.Headers.Add("upgrade-insecure-requests", "1");
            request.Headers.Add(
                "user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36"
            );
            request.Headers.Add("x-fb-lsd", "AVpnruPa-h0");
            var data = new Dictionary<string, string>()
            {
                { "__aaid", "0" },
                { "__a", "1" },
                { "__req", "1c" },
                { "dpr", "1" },
                { "__comet_req", "15" },
                { "fb_dtsg", dtsg },
                { "fb_api_caller_class", "RelayModern" },
                { "fb_api_req_friendly_name", "CometFeedStoryMenuQuery" },
                {
                    "variables",
                    "{\"input\":{\"frx_policy_education\":{\"context\":\"{\\\"session_id\\\":\\\""
                        + session_id
                        + "\\\",\\\"support_type\\\":\\\"frx\\\",\\\"type\\\":4,\\\"story_location\\\":\\\"permalink\\\",\\\"tracking\\\":\\\""
                        + tracking
                        + "\\\",\\\"entry_point\\\":\\\"chevron_button\\\",\\\"reporting_ufo_key\\\":\\\""
                        + reporting_ufo_key
                        + "\\\",\\\"frx_report_action\\\":\\\"FRX_POLICY_EDUCATION_REDIRECT\\\",\\\"rapid_reporting_tags\\\":"
                        + tags_string
                        + ",\\\"frx_feedback_submitted\\\":true,\\\"additional_data\\\":{\\\"frx_validation_ent\\\":\\\"IEntPost\\\",\\\"is_ixt_session\\\":true,\\\"is_ixt_session_logged\\\":true,\\\"checked_component_names\\\":null},\\\"screen_type\\\":\\\"frx_policy_education\\\",\\\"hideable_token\\\":\\\""
                        + hideable_token
                        + "\\\",\\\"story_permalink_token\\\":\\\""
                        + story_permalink_token
                        + "\\\"}\",\"selected_option\":\"REPORT\",\"serialized_state\":\""
                        + serialized_state
                        + "\"},\"actor_id\":\""
                        + actor_id
                        + "\",\"client_mutation_id\":\"6\"},\"scale\":1,\"__relay_internal__pv__VideoPlayerRelayReplaceDashManifestWithPlaylistrelayprovider\":true}"
                },
                { "doc_id", "7355939297820143" }
            };
            request.Content = new FormUrlEncodedContent(data);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(
                "application/x-www-form-urlencoded"
            );
            try
            {
                using HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string response_text = await response.Content.ReadAsStringAsync();
                await extra_submit_session(response_text);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }

        private async Task extra_submit_session(string response_text)
        {
            try
            {
                var response_json =
                    JsonConvert.DeserializeObject<submit_session_data_object.Rootobject>(
                        response_text
                    );
                Console.WriteLine(response_json.data.ixt_screen_next.view_model.title.text);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }
    }
}
