/*
Create a module to work with the console object.Implement functionality for:
Writing a line to the console 
Writing a line to the console using a format
Writing to the console should call toString() to each element
Writing errors and warnings to the console with and without format
*/
var specialConsole = (function () {
        // for private use
        function formatString(value, optionalParams) {
            var result = "";

            if (value) {
                result = value.toString();

                if (optionalParams) {
                    for (var i = 0, len = arguments.length; i < len - 1; i++) {
                        var pattern = "\\{" + i + "\\}";
                        var regex = new RegExp(pattern,'g');

                        result = result.replace(regex, arguments[i + 1].toString());
                    }
                }
            }

            return result;
        }

        function writeLine(value, optionalParams) {
            var result = formatString.apply(null, arguments);
            console.log(result);
        }

        function writeError(value, optionalParams) {
            var result = formatString.apply(null, arguments);
            console.error(result);
        }

        function writeWarning(value, optionalParams) {
            var result = formatString.apply(null, arguments);
            console.warn(result);
        }

        return {
            writeLine: writeLine,
            writeError: writeError,
            writeWarning: writeWarning
        };
    })();

specialConsole.writeLine("Message: hello");
//logs to the console "Message: hello"
specialConsole.writeLine("Message: {0}", "hello");
//logs to the console "Message: hello"
specialConsole.writeError("Error: {0}", "Something happened");
specialConsole.writeWarning("Warning: {0}", "A warning");