# PrimitiveColumnDb
This is a DB concept where columns are represented in separate files. Each row inside the columns are ordered in sequence. The goal is to be able to iterate in a flexible way, meaning that if you only need to read a particular column, the database will only read that info, and nothing else.

There is no need to have an index, as each column has a fixed width for the rows. The position for any row can be easily calculated.

The database will only allow you to store primitive types. This means no strings. It is aimed to be a measurement storage.