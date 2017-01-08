Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class GoogleMapsAPI
    Private Function MakeURL(origin As String, destinations As List(Of String)) As String
        Dim domain = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&"
        Dim ori = "origins=" + origin
        Dim des = "&destinations="
        For i As Integer = 0 To destinations.Count - 1
            If i = destinations.Count - 1 Then
                des &= destinations.ElementAt(i)
            Else
                des &= destinations.ElementAt(i) & "|"
            End If
        Next
        Dim APIKey As String = "&key=AIzaSyDwOjWRjYeKoezvGEHvtUfGHdS9WJ17Aco"
        Return domain & ori & des & APIKey
    End Function

    Private Function GoogleMaps(url As String) As String
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader

        Try
            request = DirectCast(WebRequest.Create(url), HttpWebRequest)

            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())

            Dim rawresp As String
            rawresp = reader.ReadToEnd()

            Return rawresp

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not response Is Nothing Then response.Close()
        End Try
        Return Nothing
    End Function

    Private Function GetDistance(jsonString As String) As List(Of Integer)
        Dim response As JObject = JObject.Parse(jsonString)
        Dim rows As IList(Of JToken) = response("rows").Children().ToList()
        Dim routes As New List(Of Integer)
        For Each result In rows
            Dim elements As JObject = JObject.Parse(result.ToString())
            Dim elems As IList(Of JToken) = elements("elements").Children().ToList()

            For Each city In elems
                Dim cities As JObject = JObject.Parse(city.ToString())
                Dim distances As IList(Of JToken) = cities("distance").Children().ToList()
                For Each distance In distances
                    If distance.ToString().Contains("value") Then
                        routes.Add(Convert.ToInt32(distance.First) / 1609)
                    End If
                Next
            Next
        Next

        Return routes
    End Function

    Public Function GetDistances(Cities As List(Of String)) As Integer(,)
        Dim origin As String = "Blacksburg, VA"
        Dim locations As New List(Of String)

        'Create a string of every possible list of destinations
        locations.Add(origin)
        For Each city In Cities
            locations.Add(city)
        Next
        Dim urls = MakeUrls(locations)


        Dim responses = MakeJsonStrings(urls)
        Dim routes = MakeRoutes(responses)


        ' TODO: Create 2D Array from JSON response and return that for use in Database
        Dim result(routes.ElementAt(0).Count - 1, routes.Count - 1) As Integer
        Dim i As Integer = 0
        For Each route In routes
            Dim j As Integer = 0
            For Each city In route
                result(j, i) = city
                j = j + 1
            Next
            i = i + 1
        Next
        Return result
    End Function

    Public Function MakeUrls(locations As List(Of String)) As List(Of String)
        Dim urls As New List(Of String)
        For i As Integer = 0 To locations.Count - 1
            Dim tempOrigin As String = ""
            Dim tempDes As New List(Of String)
            For j As Integer = 0 To locations.Count - 1
                If i = j Then
                    tempOrigin = locations.ElementAt(j)
                Else
                    tempDes.Add(locations.ElementAt(j))
                End If

            Next
            urls.Add(MakeURL(tempOrigin, tempDes))
        Next
        Return urls
    End Function

    Public Function MakeJsonStrings(urls As List(Of String)) As List(Of String)
        Dim responses As New List(Of String)
        For Each url In urls
            responses.Add(GoogleMaps(url))
        Next
        Return responses
    End Function

    Public Function MakeRoutes(responses As List(Of String)) As List(Of List(Of Integer))
        Dim routes As New List(Of List(Of Integer))
        For Each response In responses
            routes.Add(GetDistance(response))
        Next
        Return routes
    End Function
End Class
