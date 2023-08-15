C# 8 introduced explicit nullable reference types, which lets us make a
reference type null by explicitly signaling that we want to do so

In general, a good frame of mind is to limit any null returns. Because it is a value people rarely expect
to be returned (unless the return type is Nullable<T> or an explicit nullable reference
type), we should not throw the receiving method a curveball.  

Hash codes operate under the assumption that the same hash code
is always generated for the same object. So, if two objects are identical, two identical
hash codes are generated. If by chance two objects are not different but the same hash
code is generated for both of them, we speak of a hash collision. This means we have to
come up with some other way to insert the items into the array. 


1
 The average time complexity of a hash table’s insert, lookup, and search operations (and, by extension, a dic-
tionary) is O(1). The worst case for these operations is O(n). A generic list in C#, ( List<T>), acts as a dynamic
array. For a dynamic array, the average and worst-case time complexity for search, insertion, and deletion is
O(n), where n is the number of elements in the dynamic array.
2
 A hash collision is an unwanted result but not a rare occurrence. Donald Knuth writes about the “Birthday Par-
adox” in The Art of Computer Programming Volume 3: Sorting and Searching (2nd edition; Addison-Wesley, 1998):
given a hash function that generates hash codes based on a person’s birthday and a room with at least 23 peo-
ple (a map of n people to a table of size 365, one entry for each day of a non–leap year, where n  23), the
probability of at least two people sharing the same birthday (and generating the same hash code) is 0.4927.


We can generate “random” numbers in C# using the following two general methods:
 Use the Random class.
 Use the RandomNumberGenerator class.
At first glance, they may seem similar, but if we dig a little deeper, we see differences.
The Random class lives in the (root) System namespace, whereas the RandomNumber-
Generator class lives in the System.Security.Cryptography namespace. The name-
spaces in which the respective classes live provide a major hint at why they both exist:
the Random class is a low-overhead random-number picker that is very good at quickly
spitting out a number based on a time seed number. The RandomNumberGenerator
class excels at generating “random” numbers through a variety of cryptography con-
cepts, making sure that numbers are fairly unique and somewhat equally distributed
in a range over time.
In other words, if you were to use the Random class in a high throughput applica-
tion and request two random numbers at the same time, chances are you would get
the same number back from the “random” generator. Generating a pseudo-random
number is fine for a lot of applications, but for a web service, where we cannot predict
what load the system could be under, it is unsuitable. We may very well be in a situa-
tion where two people want to retrieve information for the same flight at the exact
same moment. We now have two customers generating the same hash code and a secu-
rity flaw on our hands. That is why we should use the RandomNumberGenerator class
instead of the Random class.
As you explore the world of random numbers and cryptography in C#, you
may come across people advocating the usage of the RNGCryptoService-
Provider class. The RandomNumberGenerator class is a wrapper around the
RNGCryptoServiceProvider class and much easier to use. A good resource
for further cryptography information is David Wong’s Real-World Cryptography
(Manning, 2021).

