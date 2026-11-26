# NeuKoProx

A small reverse proxy built on [YARP](https://microsoft.github.io/reverse-proxy/) and ASP.NET Core (.NET 9).
It forwards all requests to a configured destination and adds two things a bare YARP setup lacks:

- **Error pages** – when the destination is down or answers badly, visitors see a proper
  `502 – Bad Gateway` page (Razor Pages) instead of an empty response.
- **Health endpoint** – `GET /health` returns the proxy's status as JSON, ready for monitoring
  or container health checks.

YARP's own active and passive health checks watch the destination as well.

## Configuration

Routes and destinations are set in `appsettings.json` under `ReverseProxy`. The default setup uses
one catch-all route to one destination:

```json
"Clusters": {
  "cluster1": {
    "Destinations": {
      "destination1": { "Address": "https://sample-destination.demo/" }
    }
  }
}
```

Replace the address with your own backend. Further routes, clusters and load balancing follow the
[YARP configuration docs](https://microsoft.github.io/reverse-proxy/articles/config-files.html).

## Run

```bash
dotnet run --project src/NeuKoProx
```

or as a container (listens on port 8080):

```bash
docker build -f src/NeuKoProx/Dockerfile -t neukoprox .
docker run -p 8080:8080 neukoprox
```

## Error pages

Status codes are re-executed to `/Error/{code}`. To add a page for another code, create
`Pages/Error/<code>.cshtml` next to the existing `502.cshtml`.

## License

[Mozilla Public License 2.0](LICENSE.txt)

---

Made by [Michael Koch](https://github.com/MK-NEUKO) · [NeuKo know-how](https://neuko-know-how.com)
