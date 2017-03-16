<p align="center">
  <a href="https://ghpreporter.github.io/"><img src="https://github.com/GHPReporter/GHPReporter.github.io/blob/master/img/logo-small.png?raw=true" alt="Project icon"></a>
  <br><br>
  <b>Some Links:</b><br>
  <a href="https://github.com/GHPReporter/Ghpr.Core">Core</a> |
  <a href="https://github.com/GHPReporter/Ghpr.MSTest">MSTest</a> |
  <a href="https://github.com/GHPReporter/Ghpr.NUnit">NUnit</a> |
  <a href="https://github.com/GHPReporter/Ghpr.SpecFlow">SpecFlow</a> |
  <a href="https://github.com/GHPReporter/Ghpr.Console">Console</a> |
  <a href="https://github.com/GHPReporter/GHPReporter.github.io/">Site Repo</a>
</p>

[![Language](http://gh-toprated.info/Badges/LanguageBadge?user=GHPReporter&repo=Ghpr.SpecFlow&theme=light&fontWeight=bold)](https://github.com/GHPReporter/Ghpr.SpecFlow)
[![Build status](https://ci.appveyor.com/api/projects/status/jtmugpb1axnpc97g?svg=true)](https://ci.appveyor.com/project/elv1s42/ghpr-specflow)
[![NuGet Version](https://img.shields.io/nuget/v/Ghpr.SpecFlowPlugin.svg)](https://www.nuget.org/packages/Ghpr.SpecFlowPlugin)

# Ghpr.SpecFlow

## Usage:

 - Install latest nuget package
 - Add new plugin to your App.config file:

    ```xml
    <plugins>
      <add name="Ghpr" type="Runtime" />
    </plugins>
    ```
    
 - Run your tests
 
For more information see working solution example here: https://github.com/GHPReporter/Ghpr.SpecFlow.Examples
