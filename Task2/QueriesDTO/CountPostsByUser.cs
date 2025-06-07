using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.QueriesDTO;
public record CountPostsByUser
{
    private const string _delimiter = "----------------------";
    public required string UserName { get; set; }
    public string? City { get; set; }
    public int PostsCount { get; set; }

    public override string ToString()
    {
        return @$"Name: {UserName} {Environment.NewLine} 
        City: {City} {Environment.NewLine}
        PostsCount: {PostsCount}
        {Environment.NewLine}{_delimiter}{Environment.NewLine}";
    }
}
