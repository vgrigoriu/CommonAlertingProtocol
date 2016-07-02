using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CAPNet.Tests
{
    public class ElementsTests
    {
        [Fact]
        public void CanParseWithStringInsteadOfInt()
        {
            var alert = XmlParser.Parse(Xml.WrongData).First();
            var size = alert.Info.First().Resources.First().Size;
            var area = alert.Info.First().Areas.First();
            var altitude = area.Altitude;
            var ceiling = area.Ceiling;

            Assert.Null(altitude);
            Assert.Null(ceiling);
            Assert.Null(size);
        }

        [Fact]
        public void CanParseWithWrongDateTime()
        {
            var alert = XmlParser.Parse(Xml.WrongData).First();
            var sent = alert.Sent;
            var info = alert.Info.First();
            var effective = info.Effective;
            var onset = info.Onset;
            var expires = info.Expires;

            Assert.Null(sent);
            Assert.Null(effective);
            Assert.Null(expires);
            Assert.Null(onset);
        }

        [Fact]
        public void CanParseWithWrongDerefUri()
        {
            //<derefUri>abc123</derefUri> not a valid base64
            var alert = XmlParser.Parse(Xml.WrongData).First();
            var derefUri = alert.Info.First().Resources.First().DereferencedUri;
            Assert.Null(derefUri);
        }

        [Fact]
        public void CanParseWithEmptyAddress()
        {
            //<addresses> </addresses>
            var usedXml = Xml.WrongData.Replace("<addresses>addresses</addresses>", "<addresses> </addresses>");
            var alert = XmlParser.Parse(usedXml).First();
            var addresses = alert.Addresses;
            Assert.Equal(0, addresses.Count);
        }

        [Fact]
        public void CanParseAddressesWithNoQuotes()
        {
            //<addresses>address1 address2 address3</addresses>
            var usedAddress = "address1 address2 address3";
            var elements = usedAddress.GetElements();

            Assert.Equal(3, elements.Count());
            Assert.Equal(elements.ElementAt(0), "address1");
            Assert.Equal(elements.ElementAt(1), "address2");
            Assert.Equal(elements.ElementAt(2), "address3");
        }

        [Fact]
        public void CanParseAddressesWithQuotesAndNoSpaces()
        {
            //<addresses>address1 "address2" address3 "address4"</addresses>
            var usedAddress = "address1 \"address2\" address3 \"address4\"";
            var elements = usedAddress.GetElements();

            Assert.Equal(4, elements.Count());
            Assert.Equal("address1", elements.ElementAt(0));
            Assert.Equal("address2", elements.ElementAt(1));
            Assert.Equal("address3", elements.ElementAt(2));
            Assert.Equal("address4", elements.ElementAt(3));
        }

        [Fact]
        public void CanParseAddressesWithQuotesAndSpaces()
        {
            //<addresses>address1 "address 2 " "address 3" "address 4"</addresses>
            var usedAddress = "address1 \"address 2 \" \"address 3\" \"address 4\"";
            var elements = usedAddress.GetElements();

            Assert.Equal(4, elements.Count());
            Assert.Equal("address1", elements.ElementAt(0));
            Assert.Equal("address 2 ", elements.ElementAt(1));
            Assert.Equal("address 3", elements.ElementAt(2));
            Assert.Equal("address 4", elements.ElementAt(3));
        }

        [Fact]
        public void CanParseSerialAddressesWithQuotes()
        {
            //<addresses>"address1 " "address 3 " "address 4 "</addresses>
            var usedAddress = "\"address1 \" \"address 3 \" \"address 4 \"";
            var elements = usedAddress.GetElements();

            Assert.Equal(3, elements.Count());
            Assert.Equal("address1 ", elements.ElementAt(0));
            Assert.Equal("address 3 ", elements.ElementAt(1));
            Assert.Equal("address 4 ", elements.ElementAt(2));
            
        }

        [Fact]
        public void CanParseAddressesWithUntrimmedRepresentation()
        {
            //<addresses>  "address1 " "address 3 " "address 4 "    </addresses>
            var usedAddress = "   \"address1 \" \"address 3 \" \"address 4 \"   ";
            var elements = usedAddress.GetElements();

            Assert.Equal(3, elements.Count());
            Assert.Equal("address1 ", elements.ElementAt(0));
            Assert.Equal("address 3 ", elements.ElementAt(1));
            Assert.Equal("address 4 ", elements.ElementAt(2));
        }

        [Fact]
        public void CanParseAddressesWithMultipleSpaces()
        {
            //<addresses>"address1 "    "address 3 " "address 4      "</addresses>
            var usedAddress = "   \"address1 \"    \"address 3 \" \"address 4      \"";
            var elements = usedAddress.GetElements();

            Assert.Equal(3, elements.Count());
            Assert.Equal("address1 ", elements.ElementAt(0));
            Assert.Equal("address 3 ", elements.ElementAt(1));
            Assert.Equal("address 4      ", elements.ElementAt(2));
        }

        [Fact]
        public void CanParseWithSpaceAddress()
        {
            //<addresses>" " "address 3 " "address 4 "    </addresses>
            var usedAddress = "\" \" \"address 3 \" \"address 4 \"   ";
            var elements = usedAddress.GetElements();

            Assert.Equal(3, elements.Count());
            Assert.Equal(" ", elements.ElementAt(0));
            Assert.Equal("address 3 ", elements.ElementAt(1));
            Assert.Equal("address 4 ", elements.ElementAt(2));
        }

        [Fact]
        public void CanParseSingleAddress()
        {
            var usedAddress = "address";
            var elements = usedAddress.GetElements();
            Assert.Equal("address",elements.ElementAt(0));
            Assert.Equal(1, elements.Count());
        }

        [Fact]
        public void CanParseSingleAddressUntrimmed()
        {
            var usedAddress = "  address  ";
            var elements = usedAddress.GetElements();
            Assert.Equal("address", elements.ElementAt(0));
            Assert.Equal(1, elements.Count());
        }

        [Fact]
        public void CanParseSingleCharactedAddresses()
        {
            var usedAddress = "a b";
            var elements = usedAddress.GetElements();
            Assert.Equal("a", elements.ElementAt(0));
            Assert.Equal("b", elements.ElementAt(1));
            Assert.Equal(2, elements.Count());
        }

        [Fact]
        public void CanParseSingleSpaceContainingAddress()
        {
            var usedAddress = "\" address 1\"";
            var elements = usedAddress.GetElements();
            Assert.Equal(" address 1", elements.ElementAt(0));
            Assert.Equal(1, elements.Count());
        }

        [Fact]
        public void CanParseWithEmptyStringInBetweenQuotes()
        {
            var usedAddress = "\" address 1\" address2 \"\" address4";
            var elements = usedAddress.GetElements();
            Assert.Equal(" address 1", elements.ElementAt(0));
            Assert.Equal("address2", elements.ElementAt(1));
            Assert.Equal("", elements.ElementAt(2));
            Assert.Equal("address4", elements.ElementAt(3));
            Assert.Equal(4, elements.Count());
        }

        [Fact]
        public void CanParseWithAddress()
        {
            var usedAddress = "\" \" adress addr \"bs \" \"long\" \"one two three \"";
            var elements = usedAddress.GetElements();

            Assert.Equal(6, elements.Count());
            Assert.Equal(" ", elements.ElementAt(0));
            Assert.Equal("adress", elements.ElementAt(1));
            Assert.Equal("addr", elements.ElementAt(2));
            Assert.Equal("bs ", elements.ElementAt(3));
            Assert.Equal("long", elements.ElementAt(4));
            Assert.Equal("one two three ", elements.ElementAt(5));
        }

        [Fact]
        public void CanParseIncidentsWithQuotes()
        {
            var usedXml = Xml.WrongData.Replace("<incidents></incidents>", "<incidents>\"nasty incident \" incident \"another incident\"</incidents>");
            var alert = XmlParser.Parse(usedXml).First();
            var incidents = alert.Incidents;
            Assert.Equal("nasty incident ", incidents.ElementAt(0));
            Assert.Equal("incident", incidents.ElementAt(1));
            Assert.Equal("another incident", incidents.ElementAt(2));
        }

    }
}
