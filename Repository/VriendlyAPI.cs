using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Vriendly.Repository.Utilities;

namespace Vriendly.Repository.API
{
    public class VriendlyAPI
    {
        protected const string APIHost = "https://api.vriendly.co/";
        protected const string AnalyticsAPIHost = "https://analytics.vriendly.co/";

        public static IEnumerator startSession(int attempts, Action<UnityWebRequest> callback)
        {
            while (attempts > 0)
            {
                attempts--;
                string url = AnalyticsAPIHost + "startSession";
                Debug.Log("url = " + url);

                WWWForm form = new WWWForm();

                form.AddField("deviceModel", SystemInfo.deviceModel);

                form.AddField("os", SystemInfo.operatingSystem);

                Debug.Log($"deviceModel: {SystemInfo.deviceModel}, OS: {SystemInfo.operatingSystem}");
                UnityWebRequest uwr = UnityWebRequest.Post(url, form);

                uwr.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                uwr.SetRequestHeader("Authorization", "");

                yield return uwr.SendWebRequest();
                callback(uwr);
            }
        }

        public static IEnumerator endSession(int attempts, string sessionId, Action<UnityWebRequest> callback)
        {
            while (attempts > 0)
            {
                attempts--;
                string url = AnalyticsAPIHost + $"endSession/{sessionId}";
                Debug.Log("url = " + url);

                UnityWebRequest uwr = UnityWebRequest.Get(url);

                uwr.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                uwr.SetRequestHeader("Authorization", "");

                yield return uwr.SendWebRequest();
                callback(uwr);
            }
        }

        public static IEnumerator enteredRoom(int attempts, string roomId, Action<UnityWebRequest> callback)
        {
            while (attempts > 0)
            {
                attempts--;

                string url = AnalyticsAPIHost + $"enteredRoom/{roomId}";
                Debug.Log("url = " + url);

                UnityWebRequest uwr = UnityWebRequest.Get(url);

                uwr.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                uwr.SetRequestHeader("Authorization", "");

                yield return uwr.SendWebRequest();
                callback(uwr);
            }
        }

        public static IEnumerator leftRoom(int attempts, string roomSessionId, Action<UnityWebRequest> callback)
        {
            while (attempts > 0)
            {
                attempts--;

                string url = AnalyticsAPIHost + $"leftRoom/{roomSessionId}";

                Debug.Log("url = " + url);

                UnityWebRequest uwr = UnityWebRequest.Get(url);

                uwr.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                uwr.SetRequestHeader("Authorization", "");
                yield return uwr.SendWebRequest();
                callback(uwr);
            }
        }


        public static IEnumerator GetTexture(string link, Action<UnityWebRequest> callback)
        {
            UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(link);

            yield return uwr.SendWebRequest();
            callback(uwr);
        }

        public static IEnumerator signIn(string email, string password, Action<UnityWebRequest> callback)
        {

            string url = APIHost + "api/login";
            Debug.Log("url = " + url);

            WWWForm form = new WWWForm();

            form.AddField("email", email);
            form.AddField("password", Hash.getHashSha256(password));
            Debug.Log(Hash.getHashSha256(password));

            //form.headers.Add("Authorization", "Token 93745b9719cf490b1c16fbb0be37151e00d926f7d4a8ddde69829e2deb88fb43");

            UnityWebRequest uwr = UnityWebRequest.Post(url, form);

            uwr.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            yield return uwr.SendWebRequest();
            callback(uwr);
        }

        public static IEnumerator updateAvatar(string avatarData, Action<UnityWebRequest> callback)
        {
            string url = APIHost + "api/updateProfile/" + "";
            Debug.Log("url = " + url);

            WWWForm form = new WWWForm();

            Debug.Log("avatar data: " + avatarData);

            //form.headers.Add("Authorization", Repo.loginData.user.token);

            form.AddField("avatar", avatarData);

            UnityWebRequest uwr = UnityWebRequest.Post(url, form);

            uwr.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            uwr.SetRequestHeader("Authorization", "");

            yield return uwr.SendWebRequest();
            callback(uwr);
        }

        public static IEnumerator createEvent(string eventName, string placeTitle, Action<UnityWebRequest> callback)
        {
            string url = APIHost + "api/createEvent";
            Debug.Log("url = " + url);
            //yield return null;

            WWWForm form = new WWWForm();

            form.AddField("eventName", eventName);
            form.AddField("placeTitle", placeTitle);

            UnityWebRequest uwr = UnityWebRequest.Post(url, form);

            uwr.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            uwr.SetRequestHeader("Authorization", "");

            yield return uwr.SendWebRequest();
            callback(uwr);
        }

        public static IEnumerator getEvents(Action<UnityWebRequest> callback)
        {
            string url = APIHost + "api/getEventList";
            Debug.Log("url = " + url);

            WWWForm form = new WWWForm();

            UnityWebRequest uwr = UnityWebRequest.Post(url, form);

            uwr.SetRequestHeader("Authorization", "");
            uwr.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            yield return uwr.SendWebRequest();
            callback(uwr);
        }

        public static IEnumerator deleteEvent(string eventCode, Action<UnityWebRequest> callback)
        {
            string url = APIHost + "api/deleteEvent/" + eventCode;
            Debug.Log("url = " + url);

            WWWForm form = new WWWForm();

            form.AddField("eventCode", eventCode);

            UnityWebRequest uwr = UnityWebRequest.Delete(url);

            uwr.SetRequestHeader("Authorization", "");
            uwr.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            yield return uwr.SendWebRequest();
            callback(uwr);
        }

        public static IEnumerator versionControl(Action<UnityWebRequest> callback)
        {
            string url = APIHost + "api/getVersions/" + Application.companyName;
            Debug.Log(url);

            UnityWebRequest uwr = UnityWebRequest.Get(url);

            uwr.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            uwr.SetRequestHeader("Authorization", "");

            yield return uwr.SendWebRequest();
            callback(uwr);
        }
    }
}
