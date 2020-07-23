# Gluon

Gluon is a tool to manage interoperable interfaces across language and DLL boundaries. Using an interface definition, written in C#, Gluon generates and maintains a C++ class that implements the equivalent interface, as well as an equivalent C# wrapper class, or C++ PIMPL wrapper, and all of the interoperability code in between. The result is a clean public-facing API, available in either C# or C++, without the need to mire the developer in API layer plumbing.

# Compatibility
The Gluon binary depends on .Net Framework 4.5.2.

Gluon build targets depend on the Gluon runtime and [Sharpish](https://github.com/ETLang/Sharpish).

# Guide
Refer to the [API Documentation](https://codedocs.xyz/ETLang/Gluon/)

# License
 Sharpish is licensed under the MIT license.
 Copyright (c) 2020 Evan Lang
 
 Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.
 
 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 SOFTWARE.
