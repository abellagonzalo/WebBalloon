# WebBalloon
Simple web service to display notifications in the Windows icon tray bar.

## Test it!

```powerShell
$Body = @{
    Title = 'Title';
    Text = 'Text';
} | ConvertTo-Json
Invoke-RestMethod 'http://localhost:28660' -Method 'POST' -ContentType 'application/json' -Body $Body
```
