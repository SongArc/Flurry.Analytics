using System.Collections.Generic;
using Java.Lang;
using Exception = System.Exception;

namespace Flurry.Analytics
{
	public partial class FlurryAgent
	{
		public static void SetGender(Gender gender)
		{
			FlurryAgent.SetGender ((sbyte)gender);
		}

        public static void LogEvent(string eventName, List<Parameter> parameters)
        {
            FlurryAgent.LogEvent(eventName, ParametersToDictionary(parameters));
        }

        public static void LogEvent(string eventName, List<Parameter> parameters, bool timed)
        {
            FlurryAgent.LogEvent(eventName, ParametersToDictionary(parameters), timed);
        }

        public static void LogError(string message, Exception exception)
        {
            FlurryAgent.LogError(exception.Message, message, new Throwable(exception.Message));
        }

        public static void EndTimedEvent(string eventName, List<Parameter> parameters)
        {
            FlurryAgent.EndTimedEvent(eventName, ParametersToDictionary(parameters));
        }

        private static IDictionary<string, string> ParametersToDictionary(List<Parameter> parameters)
        {
            var dict = new Dictionary<string, string>();
            foreach (var parameter in parameters)
            {
                dict[parameter.Name] = parameter.Value;
            }

            return dict;
        }
	}

	public enum Gender
	{
		Male = 1,
		Female = 0,
		Unknown = -1
	}

    public class Parameter
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        public Parameter(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}

