using System;
using System.Text;

namespace RatioMaster {
  internal class RandomStringGenerator {
    private readonly char[] characterArray;
    private readonly Random randomNumbersGenerator;

    public RandomStringGenerator() {
      characterArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
      randomNumbersGenerator = new Random();
    }

    public char GetRandomCharacter() {
      return characterArray[
        (int) ((characterArray.GetUpperBound(0) + 1) * randomNumbersGenerator.NextDouble())];
    }

    public string Generate(int stringLength) {
      return Generate(stringLength, false);
    }

    public string Generate(int stringLength, bool randomness) {
      var stringBuilder = new StringBuilder {Capacity = stringLength};
      for (var count = 0; count <= stringLength - 1; count++) {
        if (randomness) {
          stringBuilder.Append((char) randomNumbersGenerator.Next(255));
        }
        else {
          stringBuilder.Append(GetRandomCharacter());
        }
      }

      return stringBuilder.ToString();
    }

    public string Generate(int stringLength, char[] charArray) {
      var stringBuilder = new StringBuilder {Capacity = stringLength};
      for (var count = 0; count <= stringLength - 1; count++) {
        stringBuilder.Append(
          charArray[(int) ((charArray.GetUpperBound(0) + 1) * randomNumbersGenerator.NextDouble())]);
      }

      return stringBuilder.ToString();
    }

    public string Generate(string inputString, bool upperCase) {
      // TODO: Use StringBuilder
      var result = string.Empty;
      for (var i = 0; i < inputString.Length; i = i + 1) {
        if (char.IsLetterOrDigit(inputString[i]) && inputString[i] < 127) {
          result += inputString[i];
        }
        else {
          result += "%";
          var temp = Convert.ToString(inputString[i], 16);
          if (upperCase) {
            temp = temp.ToUpper();
          }

          if (temp.Length == 1) {
            result += "0" + temp;
          }
          else {
            result += temp;
          }
        }
      }

      return result;
    }
  }
}