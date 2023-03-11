# ExchangeLuckyDraw
A lucky draw program for Luobotou IT Forum.

This program uses currency exchange rate as random source.

## How it is working
https://www.safe.gov.cn/AppStructured/hlw/RMBQuery.do
The RMB central parity(RATE) is updated on 9:15 am every workday.

For example, the maximum floor of the thread is 30#, there are 29 valid replies excludes the post owner.
If we draw 5 people from 29 replies,

On 2023-02-20,there are 24 RATEs on the webside, which are:

686.43        733.3        5.1102        87.535        825.69        64.499        1075.97        471.47        509.05        427.94        513.49        742.28        263.02        18903.0        53.51        54.636        5236.17        64.93        101.55        152.38        150.03        274.525        267.64        501.91

Take the first number as example:
1. remove the dot point, got 68643
2. divide by floor number - 1 (29), mod, got 0, then 0+2 = 2#, the 2# floor is the lucky floor (floor number starts from 1#).

And so on, if the number is replicated, take the next one.


## Advantage:  
1. Everyone can calculate the lucky floor after the RATE released, and it is impossible for 'covert operation' .
