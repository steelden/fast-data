# FastData

Small, simple and *UNSAFE* tools to work with raw byte arrays.

Consists of 3 utility classes:

1. `FastBuffer`
A class for reading & writing any simple data types to & from raw buffer

```c#
var buffer = new FastBuffer(10);
buffer.Do(x => {
  x.Write(20);
  x.Write(30L);
});
buffer.Do(x => {
  x.Seek(0);
  Console.WriteLine(x.ReadInt());
  Console.WriteLine(x.ReadLong());  
});
```

2. `FastCopy`
Copies bytes from source to destination
```c#
var a1 = Encoding.UTF8.GetBytes("test");
var a2 = new byte[20];
FastCopy.CopyBytes(a1, a2);
```

3. `FastCompare`
Compares source bytes to destination
Returns `0` if equal, `-1` or `1` if not
```c#
var a1 = Encoding.UTF8.GetBytes("test");
var a2 = Encoding.UTF8.GetBytes("test2");;
var result1 = FastCompare.CompareBytes(a1, a1);
Console.WriteLine(result1); // 0
var result2 = FastCompare.CompareBytes(a1, a2);
Console.WriteLine(result2); // 1
```
