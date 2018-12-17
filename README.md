<p align="center">
  <a href="https://ghpreporter.github.io/"><img src="https://github.com/GHPReporter/GHPReporter.github.io/blob/master/img/logo-small.png?raw=true" alt="Project icon"></a>
  <br><br>
  <b>Some Links:</b><br>
  <a href="https://github.com/GHPReporter/Ghpr.Core">Core</a> |
  <a href="https://github.com/GHPReporter/Ghpr.MSTest">MSTest</a> |
  <a href="https://github.com/GHPReporter/Ghpr.MSTestV2">MSTestV2</a> |
  <a href="https://github.com/GHPReporter/Ghpr.NUnit">NUnit</a> |
  <a href="https://github.com/GHPReporter/Ghpr.SpecFlow">SpecFlow</a> |
  <a href="https://github.com/GHPReporter/Ghpr.Console">Console</a> |
  <a href="https://github.com/GHPReporter/GHPReporter.github.io/">Site Repo</a>
</p>

[![Build status](https://ci.appveyor.com/api/projects/status/jtmugpb1axnpc97g?svg=true)](https://ci.appveyor.com/project/elv1s42/ghpr-specflow)
[![NuGet Version](https://img.shields.io/nuget/v/Ghpr.SpecFlowPlugin.svg)](https://www.nuget.org/packages/Ghpr.SpecFlowPlugin)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/a8d1af01424c4010b307bbb7257ff79f)](https://www.codacy.com/app/GHPReporter/Ghpr.SpecFlow?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=GHPReporter/Ghpr.SpecFlow&amp;utm_campaign=Badge_Grade)
[![CodeFactor](https://www.codefactor.io/repository/github/ghpreporter/ghpr.specflow/badge)](https://www.codefactor.io/repository/github/ghpreporter/ghpr.specflow)

# Ghpr.SpecFlow

## Usage:

 - Install latest nuget package. Use Ghpr.MSTest (if your tests are based on MSTest unit test provider) or Ghpr.NUnit (if NUnit is your unit test provider) plugin.
 - Make sure your plugin is added into App.config file:

    ```xml
    <plugins>
      <add name="Ghpr.NUnit" type="Runtime" />
    </plugins>
    ```
    
 - Run your tests
 
For more information see working solution example here: https://github.com/GHPReporter/Ghpr.SpecFlow.Examples

# Release notes

You can find it [here](https://github.com/GHPReporter/Ghpr.Core/blob/master/RELEASE_NOTES.md) for all packages.
