#Strings
Alphabet: A (finite) set of letters, A = {a, b, c, . . .}

Strings: A∗ set of finite sequences of letters (ε denotes the empty string)

Length of a string x: |x| = length of the sequence

Notation—array representation: x = x[0]x[1] . . . x[|x| − 1]
i 0 1 2 3 4 5 6 7 8
x[i] b a b a a b a b a

Alphabet of a string: alph(x) set of letters occurring effectively in x; each
letter of alph(x) appears at least once in x

Equality
x = y iff |x| = |y| and x[i] = y[i] for i = 0, 1, . . . , |x| − 1

#Factors
Concatenation or product: xy is sequence x followed by sequence y

Factor: x factor of (or occurs in) y if y is a product uxv for two strings u, v
x prefix of y if y = xv; x suffix of y if y = ux
i 0 1 2 3 4 5 6 7 8
y[i] b a b a a b a b a
left positions of aba 1 4 6
right positions of aba 3 6 8

Positions: x occurs in y at (left) position i if y = uxv and |u| = i
equivalently x = y[i]y[i + 1] . . . y[i + |x| − 1] = y[i . . i + |x| − 1]

Positions of the first occurrence:
pos(x) = min{|u| : uxA∗ ∩ yA∗ 6= ∅}

Subsequence: x subsequence of y if y = w0x[0]w1x[1] . . . x[|x| − 1]w|x| for
|x| + 1 strings w0,w1, . . . ,w|x|
equivalently, x can be obtained from y by deleting |y| − |x| letters
M.

#Powers
Power: uk is the kth power of u, defined by
u0 = ε and ue = ue−1u for e = 1, 2, . . . , k

##Lemma 1
If xm = yn for integers m, n > 0, then x, y are powers of the same string.

Primitive string: a (nonempty) string x is primitive if it is not the power
of another string — equivalently x = uk implies k = 1, and then x = u
abaab is primitive, while ε and bababa = (ba)3 are not

##Lemma 2 (Primitivity Lemma)
x is primitive iff it is a factor of x2 only as a prefix and as a suffix, that
is, ux prefix of x2 implies u = ε or u = x

* abaab occurs at positions 0, 5 only in abaababaab = (abaab)2
* bababa occurs at positions 0, 2, 4, 6 in babababababa = (bababa)2
* Proofs as exercises — consequences of the Periodicity Lemma

#Root and Conjugates

Root of x: unique primitive u for which x = uk

##Proposition 3
There exists one and only one primitive string which x 6= ε is a power of.
abaab root of itself
ba root of bababa

Conjugates: x, y are conjugates if x = uv and y = vu
abaab has 5 = |abaab| conjugates: abaab, baaba, aabab, ababa, babaa
bababa has 2 = |ba| conjugates: bababa, ababab

##Proposition 4
x, y are conjugate if and only if their roots are conjugate.

##Proposition 5
x, y are conjugate if and only if there exists a string z such that xz = zy.

#Searching for a fixed string

String matching given a pattern x, find all its locations in any text y

Pattern: a string x of symbols, of length m:  t a t a

Text: a string y of symbols, of length n:  c a c g t a t a t a t g c g t t a t a a t

Occurrences at positions 4; 6, 15


##Naive search


**public static int[] NaiveSearch(this string text, string pattern)**

*  Principles - No memorization, shift by 1 position

*  Complexity - O(m × n) time, O(1) extra space

*  Number of symbol comparisons

    * maximum ≈ m × n

    * expected ≈ 2 × n  (on a two-letter alphabet, with equiprobablity and independence conditions)

```
    pos ← 0;

    while pos ≤ n − m do

        i ← 0

        while i < m and x[i] = y[pos + i] do

            i ← i + 1

        if i = m then output(’x occurs in y at position ’, pos)

        pos ← pos + 1

```
