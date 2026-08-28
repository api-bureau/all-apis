# API Bureau APIs

This repository contains an aggregate solution that references the API clients maintained by the [API Bureau](https://github.com/api-bureau). It provides one place to explore, build, and test the clients together.

## Projects

| Project | Repository | Authentication |
| --- | --- | --- |
| All APIs | [api-bureau/all-apis](https://github.com/api-bureau/all-apis) | Aggregate solution; no provider authentication |
| Bullhorn | [api-bureau/bullhorn-api](https://github.com/api-bureau/bullhorn-api) | OAuth authorization code and refresh token flow |
| CloudCall | [api-bureau/cloudcall-api](https://github.com/api-bureau/cloudcall-api) | Password token flow, provider-specific `data.token` response, and license key |
| Confluence | [api-bureau/confluence-api](https://github.com/api-bureau/confluence-api) | Basic authentication using email and an Atlassian API token |
| Devyce | [api-bureau/devyce-api](https://github.com/api-bureau/devyce-api) | `X-API-Key` header |
| e-days | [api-bureau/e-days-api](https://github.com/api-bureau/e-days-api) | OAuth client credentials for v2; username and API key for v1 |
| Emsi / Lightcast | [api-bureau/emsi-api](https://github.com/api-bureau/emsi-api) | OAuth client credentials with scope |
| JPMorgan | [api-bureau/jpmorgan-api](https://github.com/api-bureau/jpmorgan-api) | OAuth client credentials with JPMorgan scope |
| Ringover | [api-bureau/ringover-api](https://github.com/api-bureau/ringover-api) | API key in the `Authorization` header |
| SharePoint | [api-bureau/sharepoint-api](https://github.com/api-bureau/sharepoint-api) | Not implemented in the current client project |
| Sportmonks | [api-bureau/sportmonks-api](https://github.com/api-bureau/sportmonks-api) | API token query parameter |

## Authentication helpers

Emsi, JPMorgan, and e-days currently keep a small client-credentials helper inside each API project. CloudCall and Bullhorn also keep local OAuth helpers because their flows and response formats are provider-specific.

Keeping these helpers local avoids introducing a shared package, release coordination, and cross-repository version management for a small amount of code. A shared `ApiBureau.ApiClientCore` package remains an option if the implementations gain more common behaviour or become expensive to maintain independently.