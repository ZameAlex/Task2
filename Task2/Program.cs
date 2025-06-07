using Task2;
const string _usersUri = "https://jsonplaceholder.typicode.com/users";
const string _postsUri = "https://jsonplaceholder.typicode.com/posts";

var dataFetcher = new DataFetcher();
var dataProcessor = new DataProcessor();

var posts = await dataFetcher.GetPosts(_postsUri);
var users = await dataFetcher.GetUsers(_usersUri);

var linkedUsers = dataProcessor.LinkPostsToUser(users, posts);

var queryResult = dataProcessor.PostsCountByUser(dataProcessor.FilterByNameStart(users, "S"));

foreach (var result in queryResult)
{
    Console.WriteLine(result);
}
Console.WriteLine("//////////////////////////");
Console.WriteLine();

var secondFilterResult = dataProcessor.PostsMoreThan170(linkedUsers);

foreach (var result in secondFilterResult)
{
    Console.WriteLine(result);
}