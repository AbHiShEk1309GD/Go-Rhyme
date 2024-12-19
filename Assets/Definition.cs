using System;
using System.Collections.Generic;

[Serializable]
public class Dictionary
{
    public string word;
    public List<Meanings> meanings;
}
[Serializable]
public class Meanings
{
    public List<Definitions> definitions;

}
[Serializable]
public class Definitions
{
    public string definition;
}

