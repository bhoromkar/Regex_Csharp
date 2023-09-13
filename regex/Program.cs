/*
  *	*?	Matches zero or more times.
   +	+?	Matches one or more times.
    ?	??	Matches zero or one time.
    { n }	{ n }?	Matches exactly n times.
 * ^ - Starts with
 * $ - Ends with
 * [] - Range
 * () - Group
 * . - Single character once
 * + - one or more characters in a row
 * ? - optional preceding character match (it can have or it not both)
 * \ - escape character
 * \n - New line
 * \d - Digit
 * \D - Non-digit
 * \s - White space
 * \S - non-white space
 * \w - alphanumeric/underscore character (word chars)
 * \W - non-word characters
 * {x,y} - Repeat low (x) to high (y) (no "y" means at least x, no ",y" means that many)
 * (x|y) - Alternative - x or y
 * 
 * [^x] - Anything but x (where x is whatever character you want)
 * 
Character
Description
\	
Marks the next character as either a special character or escapes a literal. For example, "n" matches the character "n". "\n" matches a newline character. The sequence "\\" matches "\" and "\(" matches "(".

Note: double quotes may be escaped by doubling them: "<a href=""...>"

^	Depending on whether the MultiLine option is set, matches the position before the first character in a line, or the first character in the string.
$	Depending on whether the MultiLine option is set, matches the position after the last character in a line, or the last character in the string.
*	Matches the preceding character zero or more times. For example, "zo*" matches either "z" or "zoo".
+	Matches the preceding character one or more times. For example, "zo+" matches "zoo" but not "z".
?	Matches the preceding character zero or one time. For example, "a?ve?" matches the "ve" in "never".
.	Matches any single character except a newline character.
(pattern)	Matches pattern and remembers the match. The matched substring can be retrieved from the resulting Matches collection, using Item [0]...[n]. To match parentheses characters ( ), use "\(" or "\)".
(?<name>pattern)	Matches pattern and gives the match a name.
(?:pattern)	A non-capturing group
(?=...)	A positive lookahead
(?!...)	A negative lookahead
(?<=...)	A positive lookbehind .
(?<!...)	A negative lookbehind .
x|y	Matches either x or y. For example, "z|wood" matches "z" or "wood". "(z|w)oo" matches "zoo" or "wood".
{n}	n is a non-negative integer. Matches exactly n times. For example, "o{2}" does not match the "o" in "Bob," but matches the first two o's in "foooood".
{n,}	n is a non-negative integer. Matches at least n times. For example, "o{2,}" does not match the "o" in "Bob" and matches all the o's in "foooood." "o{1,}" is equivalent to "o+". "o{0,}" is equivalent to "o*".
{n,m}	m and n are non-negative integers. Matches at least n and at most m times. For example, "o{1,3}" matches the first three o's in "fooooood." "o{0,1}" is equivalent to "o?".
[xyz]	A character set. Matches any one of the enclosed characters. For example, "[abc]" matches the "a" in "plain".
[^xyz]	A negative character set. Matches any character not enclosed. For example, "[^abc]" matches the "p" in "plain".
[a-z]	A range of characters. Matches any character in the specified range. For example, "[a-z]" matches any lowercase alphabetic character in the range "a" through "z".
[^m-z]	A negative range characters. Matches any character not in the specified range. For example, "[m-z]" matches any character not in the range "m" through "z".
\b	Matches a word boundary, that is, the position between a word and a space. For example, "er\b" matches the "er" in "never" but not the "er" in "verb".
\B	Matches a non-word boundary. "ea*r\B" matches the "ear" in "never early".
\d	Matches a digit character. Equivalent to [0-9].
\D	Matches a non-digit character. Equivalent to [^0-9].
\f	Matches a form-feed character.
\k	A back-reference to a named group.
\n	Matches a newline character.
\r	Matches a carriage return character.
\s	Matches any white space including space, tab, form-feed, etc. Equivalent to "[ \f\n\r\t\v]".
\S	Matches any nonwhite space character. Equivalent to "[^ \f\n\r\t\v]".
\t	Matches a tab character.
\v	Matches a vertical tab character.
\w	Matches any word character including underscore. Equivalent to "[A-Za-z0-9_]".
\W	Matches any non-word character. Equivalent to "[^A-Za-z0-9_]".
\num	Matches num, where num is a positive integer. A reference back to remembered matches. For example, "(.)\1" matches two consecutive identical characters.
\n	Matches n, where n is an octal escape value. Octal escape values must be 1, 2, or 3 digits long. For example, "\11" and "\011" both match a tab character. "\0011" is the equivalent of "\001" & "1". Octal escape values must not exceed 256. If they do, only the first two digits comprise the expression. Allows ASCII codes to be used in regular expressions.
\xn	Matches n, where n is a hexadecimal escape value. Hexadecimal escape values must be exactly two digits long. For example, "\x41" matches "A". "\x041" is equivalent to "\x04" & "1". Allows ASCII codes to be used in regular expressions.
\un	Matches a Unicode character expressed in hexadecimal notation with exactly four numeric digits. "\u0200" matches a space character.
\A	Matches the position before the first character in a string. Not affected by the MultiLine setting
\Z	Matches the position after the last character of a string. Not affected by the MultiLine setting.
\G	Specifies that the matches must be consecutive, without any intervening non-matching characters.
 */

using System.Text.RegularExpressions;



class Program
{
    static void Main(string[] args)
    {
/*
        string pattern = @"om";

        //Regex regex = new Regex(pattern);
        Console.WriteLine("omkar :" + Regex.IsMatch("omkar", pattern));
      */
        ValidateEmail("test@example.com");
        ValidatePassword("P@ssw0rd");
        ValidateName("Omkar bhor");
        ValidateZipCode("123456");
        ValidatePhoneNumber("9890810104");
    }

    static void ValidateEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        bool isValid = Regex.IsMatch(email, pattern);

        if (isValid)
        {
            Console.WriteLine("Email is Valid");

        }
        else
        {
            Console.WriteLine("Email is Invalid");
        }
    }

    static void ValidatePassword(string password)
    {
        string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[@#$%^&+=])(?=.{8,})";
        bool isValid = Regex.IsMatch(password, pattern);

        //Console.WriteLine($"Password: {password} is {(isValid ? "valid" : "invalid")}");
        if(isValid ) {
            Console.WriteLine("Password is Valid");

        }else
        {
            Console.WriteLine("Password InValid");
       }
    }

    static void ValidateName(string name)
    {
        string pattern = @"^[a-zA-Z\s]+$";
        bool isValid = Regex.IsMatch(name, pattern);

        if (isValid)
        {
            Console.WriteLine("Name is Valid");

        }
        else
        {
            Console.WriteLine("Name is  Invalid");
        }
    }

    static void ValidateZipCode(string zipCode)
    {
        string pattern = @"^\d{6}$";
        bool isValid = Regex.IsMatch(zipCode, pattern);

        if (isValid)
        {
            Console.WriteLine("Zipcode is Valid");

        }
        else
        {
            Console.WriteLine("ZipCode is Invalid");
        }
    }

    static void ValidatePhoneNumber(string phoneNumber)
    {
        string pattern = @"^\d{10}$";
        bool isValid = Regex.IsMatch(phoneNumber, pattern);

        if (isValid)
        {
            Console.WriteLine("PhoneNumber is Valid");

        }
        else
        {
            Console.WriteLine("PhoneNumber is Invalid");
        }
    }
}

