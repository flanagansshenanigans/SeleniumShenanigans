# SeleniumShenanigans

## Original Author ##
_This is purely a playground for code in selenium.
The insperation comes from my work (helping testers) or just plain curiosity.
I do think Selenium seems to be lacking in many ways.
So many basic classes have either been long unsupported or don't function as expected.
At the moment I am focusing on Chrome, but will evently wrap the drivers with an interface to create usable call methods (I hate having to specifically call chromedriver)_

## Must Knows ##
Unless specified all features are open manipulation.
In a future release, I will make a seperate library for alpha / beta classes or method signatures

## Current abilities ##
- Grab a group of IWebElements and run tasks against them in another tab without losing context (simply you don't have to care about tabs, it does it for you)

## Future abilities ##
- Support some no longer supported but useful features
- Standardise webdriver calls to different browsers, even if some of the features return unimplemented errors
